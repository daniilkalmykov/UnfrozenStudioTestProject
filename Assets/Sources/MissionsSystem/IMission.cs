namespace Sources.MissionsSystem
{
    public interface IMission
    {
        string Description { get; }
        string PlayingDescription { get; }
        int PointsAmount { get; }
        MissionStatus Status { get; }

        bool IsAvailable();
        void SetNewStatus(MissionStatus status);
    }
}