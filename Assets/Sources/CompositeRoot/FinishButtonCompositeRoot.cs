using System.Collections.Generic;
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
        [SerializeField] private List<HeroViewCompositeRoot> _heroViewCompositeRoots;
        [SerializeField] private List<HeroView> _heroViews;
        
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
            var currentMission = _levelCompositeRoot.Level.CurrentMission;

            currentMission.Complete(_playerCompositeRoot.CurrentHeroes);
            _playerCompositeRoot.ClearCurrentHeroes();
            
            foreach (var heroViewCompositeRoot in _heroViewCompositeRoots)
                heroViewCompositeRoot.ResetOptions();
            
            for (var i = 0; i < currentMission.HeroesToUnlock.Count; i++)
            {
                _heroViews[i].gameObject.SetActive(true);
                _heroViews[i].Show(currentMission.HeroesToUnlock[i]);
            }

            for (var i = currentMission.HeroesToUnlock.Count; i < _heroViews.Count; i++)
                _heroViews[i].gameObject.SetActive(false);
            
            _missionScreenView.gameObject.SetActive(false);
        }
    }
}