using Sources.MissionsSystem;

namespace Sources.LevelsSystem
{
    public interface ILevel
    {
        IMission CurrentMission { get; }

        void SetCurrentMission(IMission mission);
    }
}