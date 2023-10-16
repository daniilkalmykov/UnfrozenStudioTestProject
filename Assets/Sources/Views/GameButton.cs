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
            if (Button == null)
                return;
            
            Button.onClick.RemoveAllListeners();
            Button.onClick.AddListener(Call);
        }

        private void OnDisable()
        {
            if (Button != null)
                Button.onClick.RemoveListener(Call);
        }

        public void Init()
        {
            Button = GetComponent<Button>();

            Button.onClick.AddListener(Call);
        }

        void Call()
        {
            Clicked?.Invoke();
        }
    }
}