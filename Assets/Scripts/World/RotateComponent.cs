using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class RotateComponent : MonoBehaviour
    {
        public void Init(Vector3 targetRotate)
        {
            transform.DORotate(targetRotate, 1);
            Destroy(this);
        }
    }
}