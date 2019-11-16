using Assets.Scripts.Core.Difficulty;
using Assets.Scripts.Storage;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private StorageObj _storage;
        private IDifficultyPicker _difficultyPicker;
        
        private void Start()
        {
            _difficultyPicker = new DifficultyPicker();
            _difficultyPicker.DifficultyPicked += OnDifficultyPicked;
        }

        private void OnDifficultyPicked(DifficultyType type)
        {
            _difficultyPicker.Hide();
        }
    }
}
