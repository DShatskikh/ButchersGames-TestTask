using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public sealed class WinScreenView : MonoBehaviour
    {
        [SerializeField]
        private Button _nextButton;
        
        [SerializeField]
        private Button _x2Button;

        [SerializeField]
        private TMP_Text _levelLabel;
        
        public Button GetNextButton => _nextButton;
        public Button GetX2Button => _x2Button;
        
        public void Show() => 
            gameObject.SetActive(true);

        public void SetLevelText(string text) => 
            _levelLabel.text = text;
    }
}