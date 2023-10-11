using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[assembly: InternalsVisibleTo("Assembly-Csharp")]
namespace Sources.Views
{
    [RequireComponent(typeof(Button))]
    internal sealed class GameButton : MonoBehaviour
    {
        public Button Button { get; private set; }

        public event Action Clicked; 

        private void OnEnable()
        {
            if (Button != null)
                Button.onClick.AddListener(() => Clicked?.Invoke());
        }

        private void OnDisable()
        {
            if (Button != null)
                Button.onClick.RemoveListener(() => Clicked?.Invoke());
        }

        public void Init()
        {
            Button = GetComponent<Button>();

            Button.onClick.AddListener(() => Clicked?.Invoke());
        }
    }
}