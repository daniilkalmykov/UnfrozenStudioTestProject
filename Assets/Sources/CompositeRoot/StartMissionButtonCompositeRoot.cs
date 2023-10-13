using Sources.Views;
using UnityEngine;

namespace Sources.CompositeRoot
{
    [RequireComponent(typeof(GameButton))]
    internal sealed class StartMissionButtonCompositeRoot : CompositeRoot
    {
        [SerializeField] private MissionScreenView _missionScreen;
        [SerializeField] private PlayerCompositeRoot _playerCompositeRoot;
        [SerializeField] private MissionInfoPanelView _missionInfoPanelView;
        [SerializeField] private LevelCompositeRoot _levelCompositeRoot;
        
        private GameButton _gameButton;

        private void OnEnable()
        {
            if (_playerCompositeRoot != null)
                _playerCompositeRoot.HeroSet += OnHeroSet;
        }

        private void OnDisable()
        {
            if (_playerCompositeRoot == null)
                _playerCompositeRoot.HeroSet -= OnHeroSet;
        }

        public override void Compose()
        {
            _gameButton = GetComponent<GameButton>();
            
            _gameButton.Init();
            _gameButton.Button.interactable = false;

            _gameButton.Clicked += OnClicked;
            _playerCompositeRoot.HeroSet += OnHeroSet;
        }

        private void OnClicked()
        {
            _gameButton.Button.interactable = false;
            
            _missionScreen.gameObject.SetActive(true);
            _missionScreen.Show(_playerCompositeRoot.CurrentHeroes, _levelCompositeRoot.Level.CurrentMission);
            
            _missionInfoPanelView.gameObject.SetActive(false);
        }

        private void OnHeroSet()
        {
            _gameButton.Button.interactable = true;
        }
    }
}