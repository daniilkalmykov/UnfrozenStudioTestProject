using System;
using System.Collections.Generic;
using Sources.HeroesSystem;

namespace Sources.CompositeRoot
{
    internal sealed class PlayerCompositeRoot : CompositeRoot
    {
        private List<Hero> _heroes = new();

        public IHero CurrentHero { get; private set; } = null;

        public void TrySetCurrentHero(IHero hero)
        {
            CurrentHero = hero ?? throw new ArgumentNullException();
        }
        
        public override void Compose()
        {
            
        }
    }
}