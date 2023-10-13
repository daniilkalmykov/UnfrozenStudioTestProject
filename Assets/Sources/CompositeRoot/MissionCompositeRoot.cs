using System.Collections.Generic;
using System.Linq;
using Sources.HeroesSystem;
using Sources.MissionsSystem;
using Sources.Views;
using UnityEngine;

namespace Sources.CompositeRoot
{
    [RequireComponent(typeof(GameButton))]
    internal sealed class MissionCompositeRoot : CompositeRoot
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private string _playingDescription;
        [SerializeField] private int _pointsAmount;
        [SerializeField] private MissionStatus _status;
        [SerializeField] private List<MissionCompositeRoot> _missionsToUnlock;
        [SerializeField] private MissionInfoPanelView _infoPanel;
        [SerializeField] private string _enemyHeroName;

        private Mission _mission;
        private GameButton _gameButton;

        private void OnDisable()
        {
            if (_gameButton != null)
                _gameButton.Clicked += OnClicked;

            _mission.StatusChanged -= OnStatusChanged;
        }

        public override void Compose()
        {
            _infoPanel.gameObject.SetActive(false);
            
            var missions = _missionsToUnlock.Select(missionCompositeRoot => missionCompositeRoot._mission)
                .Cast<IMission>().ToList();

            _mission = new Mission(_description, _playingDescription, _pointsAmount, _status, missions, _name,
                new Hero(_enemyHeroName, 0));
            
            _mission.StatusChanged += OnStatusChanged;
            
            _gameButton = GetComponent<GameButton>();
            
            _gameButton.Init();
            SetButtonInteractable();

            _gameButton.Clicked += OnClicked;
        }

        private void OnStatusChanged()
        {
            SetButtonInteractable();
        }

        private void SetButtonInteractable()
        {
            _gameButton.Button.interactable = _mission.Status == MissionStatus.Available;
        }

        private void OnClicked()
        {
            _mission.SetNewStatus(MissionStatus.Completed);

            _infoPanel.gameObject.SetActive(true);
            _infoPanel.Set(_mission);
            //_mission.Complete();
        }
    }
}