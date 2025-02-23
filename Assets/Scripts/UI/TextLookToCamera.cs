using UnityEngine;

namespace Game
{
    public class TextLookToCamera : MonoBehaviour
    {
        private void Update()
        {
            transform.LookAt(Camera.main.transform);
        }
    }
}