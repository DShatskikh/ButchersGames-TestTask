using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public sealed class StartScreenView : MonoBehaviour
    {
        [SerializeField]
        private EventTrigger _eventTrigger;

        [SerializeField]
        private RectTransform _hand;
        
        [SerializeField]
        private RectTransform _handPoint1;
        
        [SerializeField]
        private RectTransform _handPoint2;
        
        public EventTrigger EventTrigger => _eventTrigger;
        public RectTransform Hand => _hand;
        public RectTransform HandPoint1 => _handPoint1;
        public RectTransform HandPoint2 => _handPoint2;

        public void Show() => 
            gameObject.SetActive(true);

        public void Hide() => 
            gameObject.SetActive(false);
    }
}