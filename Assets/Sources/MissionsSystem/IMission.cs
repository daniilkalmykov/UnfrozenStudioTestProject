using Sources.HeroesSystem;

namespace Sources.MissionsSystem
{
    public interface IMission
    {
        string Name { get; }
        string Description { get; }
        string PlayingDescription { get; }
        IHero EnemyHero { get; }
        
        void SetNewStatus(MissionStatus status);
        void Complete(IHero playerHero);
    }
}