using System;
using System.Collections.Generic;
using Sources.HeroesSystem;

namespace Sources.CompositeRoot
{
    internal sealed class PlayerCompositeRoot : CompositeRoot
    {
        private readonly HashSet<IHero> _currentHeroes = new();
        
        private List<Hero> _heroes = new();

        public event Action CurrentHeroesChanged;

        public IEnumerable<IHero> CurrentHeroes => _currentHeroes;

        public void TryAddHero(IHero newHero)
        {
            _currentHeroes.Add(newHero ?? throw new ArgumentNullException());
            
            CurrentHeroesChanged?.Invoke();
        }

        public void TryRemoveHero(IHero hero)
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
        
        public override void Compose()
        {
            //Init heroes from xml
        }
    }
}