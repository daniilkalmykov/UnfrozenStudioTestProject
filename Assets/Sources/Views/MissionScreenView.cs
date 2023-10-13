using Sources.HeroesSystem;
using Sources.MissionsSystem;
using TMPro;
using UnityEngine;

namespace Sources.Views
{
    internal sealed class MissionScreenView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playerHeroes;
        [SerializeField] private TMP_Text _enemyHeroes;
        [SerializeField] private TMP_Text _description;

        public void Show(IHero playerHero, IMission mission)
        {
            _playerHeroes.text = playerHero.Name;
            _enemyHeroes.text = mission.EnemyHero.Name;
            _description.text = mission.PlayingDescription;
        }
    }
}