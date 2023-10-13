using System;
using Sources.MissionsSystem;

namespace Sources.LevelsSystem
{
    internal sealed class Level : ILevel
    {
        public IMission CurrentMission { get; private set; }
        
        public void SetCurrentMission(IMission mission)
        {
            if (mission == null || CurrentMission == mission)
                throw new ArgumentNullException();
            
            CurrentMission = mission;
        }
    }
}