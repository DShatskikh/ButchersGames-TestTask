using UnityEngine;

namespace Game
{
    public class Mover
    {
        private Vector3 _mousePreviousPosition;
        private Vector3 _bodyPosition;
        
        private readonly float _horizontalSpeed;
        private readonly float _forwardSpeed;
        private readonly Transform _transform;
        private readonly float _maxX;
        private readonly float _minX;
        private readonly Transform _body;

        public Mover(float horizontalSpeed, float forwardSpeed, Transform transform, float minX, float maxX, Transform body)
        {
            _horizontalSpeed = horizontalSpeed;
            _forwardSpeed = forwardSpeed;
            _transform = transform;
            _maxX = maxX;
            _minX = minX;
            _body = body;
        }
        
        public void Upgrade()
        {
            if (Input.GetMouseButtonDown(0)) 
                _mousePreviousPosition = Input.mousePosition;

            if (Input.GetMouseButton(0))
            {
                Vector3 touchPosition = Input.mousePosition;
                var difference = touchPosition - _mousePreviousPosition;
                _bodyPosition = _body.localPosition;
                _bodyPosition += Vector3.right * _horizontalSpeed * difference.x * Time.deltaTime;
                _bodyPosition = _bodyPosition.SetX(Mathf.Clamp(_bodyPosition.x, _minX, _maxX));
                _body.localPosition = _bodyPosition;
                _mousePreviousPosition = Input.mousePosition;
            }

            _transform.position += _body.forward * _forwardSpeed * Time.deltaTime;
        }
    }
}