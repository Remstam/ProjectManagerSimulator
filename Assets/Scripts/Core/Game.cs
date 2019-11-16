using Assets.Scripts.Storage;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private StorageObj _storage;
        private IGameLoop _gameLoop;
        
        private void Start()
        {
            _gameLoop = new GameLoop(_storage);
            _gameLoop.Run();
        }
    }
}
