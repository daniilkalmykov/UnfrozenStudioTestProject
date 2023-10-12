namespace Sources.MissionsSystem
{
    public interface IMission
    {
        MissionStatus Status { get; }

        void TrySetNewStatus(MissionStatus status);
    }
}