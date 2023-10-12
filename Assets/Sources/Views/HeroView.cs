using Sources.HeroesSystem;
using TMPro;
using UnityEngine;

namespace Sources.Views
{
    internal sealed class HeroView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _points;

        public void Show(IHero hero)
        {
            _name.text = hero.Name;
            _points.text = hero.PointsAmount.ToString();
        }
    }
}