namespace Sources.MissionsSystem
{
    public interface IMission
    {
        string PlayerName { get; }
        string EnemyName { get; }
        string Description { get; }
        string PlayingDescription { get; }
        int PointsAmount { get; }
        MissionStatus Status { get; }
    }
}