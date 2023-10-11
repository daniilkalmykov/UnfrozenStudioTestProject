using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Views
{
    [RequireComponent(typeof(Button))]
    internal sealed class GameButton : MonoBehaviour
    {
        private Button _button;

        public event Action Clicked; 

        private void OnEnable()
        {
            if (_button != null)
                _button.onClick.AddListener(() => Clicked?.Invoke());
        }

        private void OnDisable()
        {
            if (_button != null)
                _button.onClick.RemoveListener(() => Clicked?.Invoke());
        }

        public void Init()
        {
            _button = GetComponent<Button>();

            _button.onClick.AddListener(() => Clicked?.Invoke());
        }
    }
}