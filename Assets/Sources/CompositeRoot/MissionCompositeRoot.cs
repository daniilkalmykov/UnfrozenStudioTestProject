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

        private IMission Mission => _mission;

        private void OnDisable()
        {
            if (_gameButton != null)
                _gameButton.Clicked += OnClicked;
        }

        public override void Compose()
        {
            _mission = new Mission(_description, _playingDescription, _pointsAmount, _status,
                _missionsToUnlock.Select(root => root.Mission).ToList());
            
            _gameButton = GetComponent<GameButton>();

            _gameButton.Button.interactable = _mission.IsAvailable();
            _gameButton.Clicked += OnClicked;
        }

        private void OnClicked()
        {
            _mission.SetNewStatus(MissionStatus.Completed);
        }
    }
}