using System.Collections.Generic;
using System.Linq;
using Sources.MissionsSystem;
using Sources.Views;
using UnityEngine;

namespace Sources.CompositeRoot
{
    [RequireComponent(typeof(GameButton))]
    internal sealed class MissionCompositeRoot : CompositeRoot
    {
        [SerializeField] private string _description;
        [SerializeField] private string _playingDescription;
        [SerializeField] private int _pointsAmount;
        [SerializeField] private MissionStatus _status;
        [SerializeField] private List<MissionCompositeRoot> _missionsToUnlock;

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
            var missions = _missionsToUnlock.Select(missionCompositeRoot => missionCompositeRoot._mission)
                .Cast<IMission>().ToList();

            _mission = new Mission(_description, _playingDescription, _pointsAmount, _status, missions);
            
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
            _mission.TrySetNewStatus(MissionStatus.Completed);
            _mission.UnlockNextMissions();
        }
    }
}