using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sources.HeroesSystem;

[assembly: InternalsVisibleTo("Assembly-Csharp")]
namespace Sources.MissionsSystem
{
    internal sealed class Mission : IMission
    {
        private readonly List<IMission> _missionsToUnlock;
        private readonly int _pointsAmount;
        private readonly List<IHero> _enemyHeroes;
        
        public Mission(string description, string playingDescription,
            int pointsAmount, MissionStatus status, List<IMission> missionsToUnlock, string name, List<IHero> heroes)
        {
            Description = description ?? throw new ArgumentNullException();
            PlayingDescription = playingDescription ?? throw new ArgumentNullException();
            _pointsAmount = pointsAmount;
            Status = status;
            _missionsToUnlock = missionsToUnlock;
            Name = name ?? throw new ArgumentNullException();
            _enemyHeroes = heroes ?? throw new ArgumentNullException();
        }

        public event Action StatusChanged;
        
        public string Name { get; }
        public string Description { get; }
        public string PlayingDescription { get; }
        public IEnumerable<IHero> EnemyHeroes => _enemyHeroes;
        
        public MissionStatus Status { get; private set; }

        public void SetNewStatus(MissionStatus status)
        {
            Status = status;
            
            StatusChanged?.Invoke();
        }

        public void Complete(IHero hero)
        {
            foreach (var mission in _missionsToUnlock)
                mission?.SetNewStatus(MissionStatus.Available);

            hero.AddPoints(_pointsAmount);
        }
    }
}
