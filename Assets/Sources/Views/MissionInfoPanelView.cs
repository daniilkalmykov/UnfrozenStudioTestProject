using System;
using Sources.CompositeRoot;
using Sources.MissionsSystem;
using TMPro;
using UnityEngine;

namespace Sources.Views
{
    internal sealed class MissionInfoPanelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private TMP_Text _pickedHeroes;
        [SerializeField] private PlayerCompositeRoot _playerCompositeRoot;

        private IMission _currentMission;

        private void OnDisable()
        {
            if (_playerCompositeRoot != null)
                _playerCompositeRoot.Character.CurrentHeroesChanged -= OnCurrentHeroesChanged;
        }

        public void Set(IMission mission)
        {
            _currentMission = mission ?? throw new ArgumentNullException();
            
            _name.text = mission.Name;
            _description.text = mission.Description;
            _pickedHeroes.text = "0/" + mission.PlayerHeroesAmount;
            
            _playerCompositeRoot.Character.CurrentHeroesChanged += OnCurrentHeroesChanged;
        }

        private void OnCurrentHeroesChanged()
        {
            _pickedHeroes.text = $"{_playerCompositeRoot.Character.GetAmountOfHeroes()}/" +
                                 _currentMission.PlayerHeroesAmount;
        }
    }
}