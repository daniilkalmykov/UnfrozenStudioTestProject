using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Assembly-Csharp")]
namespace Sources.HeroesSystem
{
    internal sealed class Hero : IHero
    {
        public Hero(string name, int pointsAmount)
        {
            Name = name;
            PointsAmount = pointsAmount;
        }

        public string Name { get; }
        public int PointsAmount { get; private set; }
        
        public void AddPoints(int points)
        {
            if (points <= 0)
                throw new ArgumentException();
            
            PointsAmount += points;
        }

        public void ReducePoints(int points)
        {
            if (points <= 0)
                throw new ArgumentException();
            
            PointsAmount -= points;
        }
    }
}