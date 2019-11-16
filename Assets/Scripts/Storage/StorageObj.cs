using Assets.Scripts.View;
using Code.Alex;
using UnityEngine;

namespace Assets.Scripts.Storage
{
    public class StorageObj : MonoBehaviour, IStorage, IPrefabStorage
    {
        [SerializeField] private Transform _canvasTransform;
        [SerializeField] private LevelSetup _levelSetup;
        [SerializeField] private DifficultyPickerView _difficultyPickerViewPrefab;

        public IDifficultyPickerView GetDifficultyPickerView()
        {
            var obj = Instantiate(_difficultyPickerViewPrefab, _canvasTransform, false);
            return obj;
        }
    }
}