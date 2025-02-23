using TMPro;
using UnityEngine;

namespace Game
{
    public sealed class GameScreenView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _levelLabel;
        
        [SerializeField]
        private TMP_Text _dollarsLabel;

        public void Show() => 
            gameObject.SetActive(true);

        public void SetDollars(string text) => 
            _dollarsLabel.text = text;
        
        public void SetLevel(string text) => 
            _levelLabel.text = text;
    }
}