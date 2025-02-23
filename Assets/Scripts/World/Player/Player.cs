using MoreMountains.Feedbacks;
using Sirenix.OdinInspector;
using UniRx;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Game
{
    public class Player : MonoBehaviour, IGameStartListener, IGameLoseListener, IGameWinListener
    {
        [Header("Settings")]
        [SerializeField]
        private float _moveHorizontalSpeed = 0.5f;

        [SerializeField]
        private float _moveForwardSpeed = 0.5f;
        
        [SerializeField]
        private int _startDollars = 40;

        [SerializeField]
        private DollarStateData[] _dollarStates;

        [SerializeField]
        private float _minX = 3;
        
        [SerializeField]
        private float _manX = 3;
        
        [Header("Links")]
        [SerializeField]
        private PlayerView _view;

        [SerializeField]
        private CinemachineVirtualCameraBase _camera;

        [SerializeField]
        private Transform _body;

        [SerializeField]
        private MMF_Player _dollarFeedback;
        
        private Mover _mover;
        private bool _isPlaying;
        private IntReactiveProperty _dollars = new();
        private GameStateMachine _gameStateMachine;
        private int _multiply;

        public IReadOnlyReactiveProperty<int> GetDollars => _dollars;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _mover = new Mover(_moveHorizontalSpeed, _moveForwardSpeed, transform, _minX, _manX, _body);

            _dollars.Subscribe(OnUpgradeDollar);
            _dollars.Value = _startDollars;
        }

        private void Update()
        {
            if (_isPlaying)
            {
                _mover.Upgrade();
            }
        }
        
        public void OnStartGame()
        {
            _isPlaying = true;
            _camera.gameObject.SetActive(true);
        }

        public void OnLoseGame()
        {
            _isPlaying = false;
        }

        public void OnFinishGame()
        {
            _isPlaying = false;
        }

        [Button]
        public void AddDollar(int count)
        {
            _dollars.Value += count;
            MMF_FloatingText floatingText = _dollarFeedback.GetFeedbackOfType<MMF_FloatingText>();
            floatingText.Value = $"+{count}$";
            _dollarFeedback.PlayFeedbacks(transform.position.AddY(2f));
            Debug.Log("Add Dollars: " + count + " All: " + _dollars.Value);
        }

        [Button]
        public void RemoveDollar(int count)
        {
            _dollars.Value -= count;
            Debug.Log("Remove Dollars: " + count + " All: " + _dollars.Value);

            if (_dollars.Value <= 0)
            {
                Debug.Log("Вы проиграли");
                _gameStateMachine.LoseGame();
            }
        }
        
        private void OnUpgradeDollar(int value)
        {
            DollarStateData data = _dollarStates[^1];
            
            foreach (var pair in _dollarStates) 
                pair.Mesh.gameObject.SetActive(false);

            foreach (var stateData in _dollarStates)
            {
                if (value >=stateData.Dollars)
                {
                    data = stateData;
                    break;
                }
            }

            _view.SelectMesh(data.Mesh);
        }

        public void SetMultiply(int multiply)
        {
            _multiply = multiply;
        }
    }
}