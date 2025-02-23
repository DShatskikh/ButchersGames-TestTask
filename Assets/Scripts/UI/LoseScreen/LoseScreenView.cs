using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public sealed class LoseScreenView : MonoBehaviour
    {
        [SerializeField]
        private Button _resetButton;
        
        public Button GetResetButton => _resetButton;
        
        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}