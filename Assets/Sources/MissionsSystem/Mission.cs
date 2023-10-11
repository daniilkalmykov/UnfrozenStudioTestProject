using System;
using System.Collections.Generic;
using System.Linq;

namespace Sources.MissionsSystem
{
    internal sealed class Mission : IMission
    {
        private readonly List<Mission> _missionsToUnlock;
        
        public Mission(string description, string playingDescription,
            int pointsAmount, MissionStatus status, List<Mission> missionsToUnlock)
        {
            Description = description;
            PlayingDescription = playingDescription;
            PointsAmount = pointsAmount;
            Status = status;
            _missionsToUnlock = missionsToUnlock;
        }

        public string Description { get; }
        public string PlayingDescription { get; }
        public int PointsAmount { get; }
        public MissionStatus Status { get; private set; }

        public bool IsAvailable()
        {
            return _missionsToUnlock.All(
                mission => mission.Status is MissionStatus.Available or MissionStatus.Completed);
        }

        public void SetNewStatus(MissionStatus status)
        {
            if (Status == status)
                throw new ArgumentException();
            
            Status = status;
        }
    }
}
