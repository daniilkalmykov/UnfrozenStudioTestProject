using System;
using System.Collections.Generic;
using Sources.HeroesSystem;

namespace Sources.CompositeRoot
{
    internal sealed class PlayerCompositeRoot : CompositeRoot
    {
        private List<Hero> _heroes = new();

        public event Action HeroSet;
        
        public IHero CurrentHero { get; private set; }

        public void TrySetCurrentHero(IHero hero)
        {
            CurrentHero = hero ?? throw new ArgumentNullException();
            
            HeroSet?.Invoke();
        }
        
        public override void Compose()
        {
            //Init heroes from xml
        }
    }
}