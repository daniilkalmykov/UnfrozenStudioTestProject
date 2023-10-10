namespace Sources.HeroesSystem
{
    public interface IHero
    {
        string Name { get; }
        int PointsAmount { get; }

        void AddPoints();
        void ReducePoints();
    }
}