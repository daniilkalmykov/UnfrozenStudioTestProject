using Sources.HeroesSystem;
using Sources.Views;
using UnityEngine;

namespace Sources.CompositeRoot
{
    [RequireComponent(typeof(GameButton))]
    [RequireComponent(typeof(HeroView))]
    internal sealed class HeroViewCompositeRoot : CompositeRoot
    {
        [SerializeField] private PlayerCompositeRoot _playerCompositeRoot;
        [SerializeField] private string _name;
        
        private HeroView _heroView;
        private GameButton _gameButton;
        private Hero _hero;

        private void OnEnable()
        {
            if(_gameButton != null)
                _gameButton.Clicked += OnClicked;
        }

        private void OnDisable()
        {
            if (_gameButton != null)
                _gameButton.Clicked -= OnClicked;
        }

        public override void Compose()
        {
            _hero = new Hero(_name, 0);
            
            _heroView = GetComponent<HeroView>();
            _gameButton = GetComponent<GameButton>();
            
            _gameButton.Init();
            _gameButton.Clicked += OnClicked;

            _heroView.Show(_hero);
        }

        private void OnClicked()
        {
            _playerCompositeRoot.TrySetCurrentHero(_hero);
        }
    }
}