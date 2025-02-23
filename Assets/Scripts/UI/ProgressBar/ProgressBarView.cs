using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ProgressBarView : MonoBehaviour
    {
        [SerializeField]
        private Slider _slider;

        [SerializeField]
        private TMP_Text _label;

        public void SetText(string text) => 
            _label.text = text;

        public void SetBar(int value) => 
            _slider.value = value;

        public void Show() => 
            gameObject.SetActive(true);
    }
}