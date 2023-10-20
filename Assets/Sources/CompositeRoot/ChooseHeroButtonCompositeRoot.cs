using System;
using Sources.HeroesSystem;
using Sources.Views;
using UnityEngine;

namespace Sources.CompositeRoot
{
    [RequireComponent(typeof(GameButton))]
    internal sealed class ChooseHeroButtonCompositeRoot : CompositeRoot
    {
        [SerializeField] private PlayerCompositeRoot _playerCompositeRoot;

        private IHero _hero;
        private GameButton _gameButton;

        private void OnEnable()
        {
            if (_gameButton == null) 
                return;
            
            _gameButton.Clicked -= OnClicked;
            _gameButton.Clicked += OnClicked;
        }
        
        private void OnDisable()
        {
            if (_gameButton != null)
                _gameButton.Clicked -= OnClicked;
        }

        public void SetNewHero(IHero hero)
        {
            _hero = hero ?? throw new ArgumentNullException();
        }
        
        public override void Compose()
        {
            _gameButton = GetComponent<GameButton>();
            
            _gameButton.Init();
            _gameButton.Clicked += OnClicked;
        }

        private void OnClicked()
        {
            _playerCompositeRoot.Character.TryAddHero(_hero);
            gameObject.SetActive(false);
        }
    }
}