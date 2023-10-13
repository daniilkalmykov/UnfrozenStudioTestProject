using Sources.Views;
using UnityEngine;

namespace Sources.CompositeRoot
{
    [RequireComponent(typeof(GameButton))]
    internal sealed class FinishButtonCompositeRoot : CompositeRoot
    {
        [SerializeField] private LevelCompositeRoot _levelCompositeRoot;
        [SerializeField] private PlayerCompositeRoot _playerCompositeRoot;
        [SerializeField] private MissionScreenView _missionScreenView;
        
        private GameButton _gameButton;

        private void OnEnable()
        {
            if (_gameButton != null)
                _gameButton.Clicked += OnClicked;
        }

        private void OnDisable()
        {
            if (_gameButton != null)
                _gameButton.Clicked -= OnClicked;
        }

        public override void Compose()
        {
            _gameButton = GetComponent<GameButton>();
            
            _gameButton.Init();
            _gameButton.Clicked += OnClicked;
        }

        private void OnClicked()
        {
            _levelCompositeRoot.Level.CurrentMission.Complete(_playerCompositeRoot.CurrentHeroes);

            _playerCompositeRoot.ClearCurrentHeroes();
            _missionScreenView.gameObject.SetActive(false);
        }
    }
}