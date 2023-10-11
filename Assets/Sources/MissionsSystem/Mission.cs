using System;
using System.Collections.Generic;
using System.Linq;
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

        public string Description { get; }
        public string PlayingDescription { get; }
        public int PointsAmount { get; }
        public MissionStatus Status { get; private set; }

        public bool IsAvailable()
        {
            return _missionsToUnlock == null || _missionsToUnlock.All(mission =>
                mission.Status is MissionStatus.Completed);
        }

        public void SetNewStatus(MissionStatus status)
        {
            if (Status == status)
                throw new ArgumentException();
            
            Status = status;
        }
    }
}
