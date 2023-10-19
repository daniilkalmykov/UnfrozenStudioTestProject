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
        private bool _isPicked;

        public IHero Hero => _hero;

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

        public override void Compose()
        {
            _hero = new Hero(_name, 0);
            
            _heroView = GetComponent<HeroView>();
            _gameButton = GetComponent<GameButton>();
            
            _gameButton.Init();
            _gameButton.Clicked += OnClicked;

            _heroView.Show(_hero);
            _playerCompositeRoot.HeroChanged += OnHeroChanged;
        }

        private void OnHeroChanged(Hero hero)
        {
            if (_hero == hero)
                gameObject.SetActive(true);
        }

        private void OnClicked()
        {
            if (_isPicked)
            {
                _playerCompositeRoot.TryRemoveCurrentHero(_hero);
                _isPicked = false;
            }
            else
            {
                _playerCompositeRoot.TryAddCurrentHero(_hero);
                _isPicked = true;
            }
        }

        public void ResetOptions()
        {
            _isPicked = false;
        }
    }
}