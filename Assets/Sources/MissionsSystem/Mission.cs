using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Assembly-Csharp")]
namespace Sources.MissionsSystem
{
    internal sealed class Mission : IMission
    {
        private readonly List<IMission> _missionsToUnlock;
        
        public Mission(string description, string playingDescription,
            int pointsAmount, MissionStatus status, List<IMission> missionsToUnlock)
        {
            Description = description ?? throw new ArgumentNullException();
            PlayingDescription = playingDescription ?? throw new ArgumentNullException();
            PointsAmount = pointsAmount;
            Status = status;
            _missionsToUnlock = missionsToUnlock;
        }

        public event Action StatusChanged;
        
        public string Description { get; }
        public string PlayingDescription { get; }
        public int PointsAmount { get; }
        public MissionStatus Status { get; private set; }

        public void TrySetNewStatus(MissionStatus status)
        {
            Status = status;
            
            StatusChanged?.Invoke();
        }

        public void UnlockNextMissions()
        {
            foreach (var mission in _missionsToUnlock)
                mission?.TrySetNewStatus(MissionStatus.Available);
        }
    }
}
