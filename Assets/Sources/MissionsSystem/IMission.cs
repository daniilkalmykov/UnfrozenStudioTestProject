namespace Sources.MissionsSystem
{
    public interface IMission
    {
        string Name { get; }
        string Description { get; }
        
        void SetNewStatus(MissionStatus status);
    }
}