namespace Sources.MissionsSystem
{
    public sealed class Mission : IMission
    {
        public Mission(string playerName, string enemyName, string description, string playingDescription,
            int pointsAmount, MissionStatus status)
        {
            PlayerName = playerName;
            EnemyName = enemyName;
            Description = description;
            PlayingDescription = playingDescription;
            PointsAmount = pointsAmount;
            Status = status;
        }

        public string PlayerName { get; }
        public string EnemyName { get; }
        public string Description { get; }
        public string PlayingDescription { get; }
        public int PointsAmount { get; }
        public MissionStatus Status { get; }
    }
}
