using System;
using System.Collections.Generic;
using Sources.HeroesSystem;

namespace Sources.CharactersSystem
{
    internal sealed class Character : ICharacter
    {
        private readonly HashSet<IHero> _currentHeroes = new();
        private readonly List<IHero> _heroes = new();
        
        public event Action CurrentHeroesChanged;
        public event Action<IHero> HeroChanged;
        
        public IEnumerable<IHero> CurrentHeroes => _currentHeroes;

        public void TryAddHero(IHero hero)
        {
            _heroes.Add(hero ?? throw new ArgumentNullException());
            
            HeroChanged?.Invoke(hero);
        }
        
        public void TryAddCurrentHero(IHero newHero)
        {
            _currentHeroes.Add(newHero ?? throw new ArgumentNullException());
            
            CurrentHeroesChanged?.Invoke();
        }

        public void TryRemoveCurrentHero(IHero hero)
        {
            if (hero == null || _currentHeroes.Contains(hero) == false)
                throw new ArgumentNullException();
            
            _currentHeroes.Remove(hero);
            
            CurrentHeroesChanged?.Invoke();
        }

        public int GetAmountOfHeroes() => _currentHeroes.Count;
        
        public void ClearCurrentHeroes()
        {
            _currentHeroes.Clear();
        }
    }
}