using System.Collections.Generic;
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

        public void Show(IEnumerable<IHero> playerHeroes, IMission mission)
        {
            _playerHeroes.text = string.Empty;
            _enemyHeroes.text = string.Empty;
            _description.text = string.Empty;

            foreach (var playerHero in playerHeroes)
                _playerHeroes.text += playerHero.Name + '\n';
            
            foreach (var missionEnemyHero in mission.EnemyHeroes)
                _enemyHeroes.text += missionEnemyHero.Name + '\n';
            
            _description.text = mission.PlayingDescription;
        }
    }
}