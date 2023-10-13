using System.Collections.Generic;
using Sources.HeroesSystem;

namespace Sources.MissionsSystem
{
    public interface IMission
    {
        string Name { get; }
        string Description { get; }
        string PlayingDescription { get; }
        IEnumerable<IHero> EnemyHeroes { get; }
        
        void SetNewStatus(MissionStatus status);
        void Complete(IHero playerHero);
    }
}