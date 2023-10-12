namespace Sources.MissionsSystem
{
    public interface IMission
    {
        void TrySetNewStatus(MissionStatus status);
    }
}