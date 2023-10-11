using System.Collections.Generic;
using System.Linq;
using Sources.MissionsSystem;
using UnityEngine;

namespace Sources.CompositeRoot
{
    internal sealed class MissionCompositeRoot : CompositeRoot
    {
        [SerializeField] private string _description;
        [SerializeField] private string _playingDescription;
        [SerializeField] private int _pointsAmount;
        [SerializeField] private MissionStatus _status;
        [SerializeField] private List<MissionCompositeRoot> _missionsToUnlock;

        private Mission _mission;

        private IMission Mission => _mission;
        
        public override void Compose()
        {
            _mission = new Mission(_description, _playingDescription, _pointsAmount, _status,
                _missionsToUnlock.Select(root => root.Mission).ToList());
        }
    }
}