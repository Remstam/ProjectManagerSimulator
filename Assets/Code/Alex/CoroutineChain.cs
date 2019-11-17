using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Alex
{
    #region Accessor

    public enum ELogType
    {
        Normal,
        Warrning,
        Error
    }

    public static class MonoBehaviourExtend
    {
        public static ChainBase StartChain(this MonoBehaviour mono)
        {
            return ChainBase.BasePool.Spawn(mono);
        }
    }

    public static class CoroutineChain
    {
        private class Dispather : MonoBehaviour
        {
        }

        private static Dispather _mInstance;

        private static Dispather Instance
        {
            get
            {
                if (_mInstance == null)
                {
                    _mInstance = new GameObject("CoroutineChain").AddComponent<Dispather>();
                    Object.DontDestroyOnLoad(_mInstance);
                }

                return _mInstance;
            }
        }

        public static void StopAll()
        {
            _mInstance.StopAllCoroutines();
        }

        public static ChainBase Start => ChainBase.BasePool.Spawn(Instance);
    }

    #endregion

    #region Util

    public class MemoryPool<T, TParam> where T : new()
    {
        private Stack<T> _mPool = new Stack<T>();

        private readonly Action<T, TParam> _onSpawn;
        private readonly Action<T> _onDespawn;

        public MemoryPool(Action<T, TParam> onSpawn = null, Action<T> onDespawn = null)
        {
            _onDespawn = onDespawn;
            _onSpawn = onSpawn;
        }

        public T Spawn(TParam init)
        {
            var item = _mPool.Count == 0 ? new T() : _mPool.Pop();
            _onSpawn?.Invoke(item, init);
            return item;
        }

        public void Despawn(T item)
        {
            _onDespawn?.Invoke(item);
            _mPool.Push(item);
        }
    }

    public class MemoryPool<T> where T : new()
    {
        private Stack<T> _mPool = new Stack<T>();

        private readonly Action<T> _onSpawn;
        private readonly Action<T> _onDespawn;

        public MemoryPool(Action<T> onSpawn = null, Action<T> onDespawn = null)
        {
            _onDespawn = onDespawn;
            _onSpawn = onSpawn;
        }

        public T Spawn()
        {
            var item = _mPool.Count == 0 ? new T() : _mPool.Pop();
            _onSpawn?.Invoke(item);
            return item;
        }

        public void Despawn(T item)
        {
            _onDespawn?.Invoke(item);
            _mPool.Push(item);
        }
    }

    #endregion

    #region CChainInternal

    public class Chain
    {
        private EType _type;
        private MonoBehaviour _player;
        private IEnumerator _routine;
        private IEnumerator[] _parallelRoutine;
        private Action _action;

        public Coroutine Play()
        {
            switch (_type)
            {
                default:
                case EType.NonCoroutine:
                    _action();
                    return null;
                case EType.Parallel:
                    return _player.StartCoroutine(Parallel(_parallelRoutine));
                case EType.Single:
                    return _player.StartCoroutine(_routine);
            }
        }

        public Chain SetupRoutine(IEnumerator routine, MonoBehaviour player)
        {
            _type = EType.Single;
            _player = player;
            _routine = routine;
            return this;
        }

        public Chain SetupParallel(IEnumerator[] routines, MonoBehaviour player)
        {
            _type = EType.Parallel;
            _player = player;
            _parallelRoutine = routines;
            return this;
        }

        public Chain SetupNon(Action action, MonoBehaviour player)
        {
            _type = EType.NonCoroutine;
            _player = player;
            _action = action;
            return this;
        }

        public void Clear()
        {
            _player = null;
            _routine = null;
            _action = null;
            _parallelRoutine = null;
        }

        private IEnumerator Parallel(IEnumerator[] routines)
        {
            var all = routines.Length;

            var c = 0;
            foreach (var r in routines)
                _player.StartChain()
                    .Play(r)
                    .Call(() => c++);

            while (c < all)
                yield return null;
        }

        public enum EType
        {
            Single,
            Parallel,
            NonCoroutine
        }
    }

    public interface IChain
    {
        Coroutine Play(MonoBehaviour mono);
    }

    public class ChainBase : CustomYieldInstruction
    {
        public static MemoryPool<ChainBase, MonoBehaviour> BasePool =
            new MemoryPool<ChainBase, MonoBehaviour>((c, m) => c.Setup(m), c => c.Clear());

        public static MemoryPool<Chain> ChainPool = new MemoryPool<Chain>(null, c => c.Clear());


        private MonoBehaviour _player;

        private Queue<Chain> _mChainQueue = new Queue<Chain>();

        private bool _mIsPlay = true;

        public override bool keepWaiting => _mIsPlay;

        private ChainBase Setup(MonoBehaviour player)
        {
            _mIsPlay = true;
            _player = player;
            _player.StartCoroutine(Routine());
            return this;
        }

        private void Clear()
        {
            _player = null;
            _mChainQueue.Clear();
        }

        private IEnumerator Routine()
        {
            yield return null;

            while (_mChainQueue.Count > 0)
            {
                var chain = _mChainQueue.Dequeue();
                var cr = chain.Play();
                if (cr != null)
                    yield return cr;
                ChainPool.Despawn(chain);
            }

            _mIsPlay = false;
            BasePool.Despawn(this);
        }

        public ChainBase Play(IEnumerator routine)
        {
            _mChainQueue.Enqueue(ChainPool.Spawn().SetupRoutine(routine, _player));
            return this;
        }

        public ChainBase Wait(float waitSec)
        {
            _mChainQueue.Enqueue(ChainPool.Spawn().SetupRoutine(WaitRoutine(waitSec), _player));
            return this;
        }

        public ChainBase Parallel(params IEnumerator[] routines)
        {
            _mChainQueue.Enqueue(ChainPool.Spawn().SetupParallel(routines, _player));
            return this;
        }

        public ChainBase Sequential(params IEnumerator[] routines)
        {
            foreach (var routine in routines)
                _mChainQueue.Enqueue(ChainPool.Spawn().SetupRoutine(routine, _player));
            return this;
        }

        public ChainBase Log(string log, ELogType type = ELogType.Normal)
        {
            Action action;
            switch (type)
            {
                default:
                case ELogType.Normal:
                    action = () => Debug.Log(log);
                    break;
                case ELogType.Warrning:
                    action = () => Debug.LogWarning(log);
                    break;
                case ELogType.Error:
                    action = () => Debug.LogError(log);
                    break;
            }

            _mChainQueue.Enqueue(ChainPool.Spawn().SetupNon(action, _player));
            return this;
        }

        public ChainBase Call(Action action)
        {
            _mChainQueue.Enqueue(ChainPool.Spawn().SetupNon(action, _player));
            return this;
        }

        private IEnumerator WaitRoutine(float wait)
        {
            yield return new WaitForSeconds(wait);
        }
    }

    #endregion
}