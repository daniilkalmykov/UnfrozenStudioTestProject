using System;
using System.Collections.Generic;
using Sources.HeroesSystem;

namespace Sources.CharactersSystem
{
    public interface ICharacter
    {
        event Action CurrentHeroesChanged;
        event Action<IHero> HeroChanged;
        
        IEnumerable<IHero> CurrentHeroes { get; }
    
        public void TryAddHero(IHero hero);
        public void TryAddCurrentHero(IHero newHero);
        public void TryRemoveCurrentHero(IHero hero);
        public int GetAmountOfHeroes();
        public void ClearCurrentHeroes();
    }
}