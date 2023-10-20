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
                _playerCompositeRoot.Character.CurrentHeroesChanged += OnCurrentHeroesChanged;
        }

        private void OnDisable()
        {
            if (_playerCompositeRoot == null)
                _playerCompositeRoot.Character.CurrentHeroesChanged -= OnCurrentHeroesChanged;
        }

        public override void Compose()
        {
            _gameButton = GetComponent<GameButton>();
            
            _gameButton.Init();
            _gameButton.Button.interactable = false;

            _gameButton.Clicked += OnClicked;
            _playerCompositeRoot.Character.CurrentHeroesChanged += OnCurrentHeroesChanged;
        }

        private void OnClicked()
        {
            _gameButton.Button.interactable = false;
            
            _missionScreen.gameObject.SetActive(true);
            _missionScreen.Show(_playerCompositeRoot.Character.CurrentHeroes, _levelCompositeRoot.Level.CurrentMission);
            
            _missionInfoPanelView.gameObject.SetActive(false);
        }

        private void OnCurrentHeroesChanged()
        {
            _gameButton.Button.interactable = _levelCompositeRoot.Level.CurrentMission.PlayerHeroesAmount ==
                                              _playerCompositeRoot.Character.GetAmountOfHeroes();
        }
    }
}