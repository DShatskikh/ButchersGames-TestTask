using System;
using UnityEngine;

namespace Game
{
    public class Test : MonoBehaviour
    {
        [SerializeField]
        private Transform _body;
        
        private void Update()
        {
            _body.localPosition += Time.deltaTime * Vector3.right * Input.GetAxis("Horizontal");
        }
    }
}