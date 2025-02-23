using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class GameStateMachine : ITickable, IFixedTickable
    {
        private GameState _gameState;
        
        private readonly List<IGameListener> _listeners = new ();
        private readonly List<IGameTickableListener> _tickables = new ();
        private readonly List<IGameFixedTickableListener> _fixedTickables = new ();
        
        public GameState GetState => _gameState;

        public void AddListener(IGameListener listener) 
        {
            if (listener == null || _listeners.Any(x => x == listener))
                return;
            
            _listeners.Add(listener);
            
            if (listener is IGameTickableListener tickableListener)
                _tickables.Add(tickableListener);
            
            if (listener is IGameFixedTickableListener fixedUpdateListener)
                _fixedTickables.Add(fixedUpdateListener);
        }

        public void RemoveListener(IGameListener listener) 
        {
            if (listener is IGameTickableListener tickableListener)
                _tickables.Remove(tickableListener);
            
            if (listener is IGameFixedTickableListener fixedUpdateListener)
                _fixedTickables.Remove(fixedUpdateListener);
            
            _listeners.Remove(listener);
        }

        public void Tick()
        {
            if (_gameState == GameState.PLAYING)
            {
                var delta = Time.deltaTime;
            
                foreach (var tickable in _tickables) 
                    tickable.Tick(delta);
            }
        }

        public void FixedTick()
        {
            if (_gameState == GameState.PLAYING)
            {
                var delta = Time.fixedDeltaTime;
                
                foreach (var fixedTickable in _fixedTickables)
                    fixedTickable.FixedTick(delta);
            }
        }
        
        public void StartGame() 
        {
            if (_gameState != GameState.OFF && _gameState != GameState.WIN)
                return;

            for (int i = 0; i < _listeners.Count; i++)
            {
                if (_listeners[i] is IGameStartListener startListeners) 
                    startListeners.OnStartGame();
            }

            _gameState = GameState.PLAYING;
            Debug.Log("Start Game");
        }

        public void PauseGame()
        {
            if (_gameState != GameState.PLAYING)
                return;
            
            for (int i = 0; i < _listeners.Count; i++)
            {
                if (_listeners[i] is IGamePauseListener pauseListeners) 
                    pauseListeners.OnPauseGame();
            }

            _gameState = GameState.PAUSED;
        }

        public void ResumeGame()
        {
            if (_gameState != GameState.PAUSED)
                return;
            
            for (int i = 0; i < _listeners.Count; i++)
            {
                if (_listeners[i] is IGameResumeListener resumeListeners) 
                    resumeListeners.OnResumeGame();
            }
            
            _gameState = GameState.PLAYING;
        }

        public void WinGame()
        {
            if (_gameState != GameState.PAUSED && _gameState != GameState.PLAYING)
                return;
            
            for (int i = 0; i < _listeners.Count; i++)
            {
                if (_listeners[i] is IGameWinListener finishListeners) 
                    finishListeners.OnFinishGame();
            }

            _gameState = GameState.WIN;
            Debug.Log("Win!");
        }
        
        public void LoseGame()
        {
            if (_gameState != GameState.PAUSED && _gameState != GameState.PLAYING)
                return;
            
            for (int i = 0; i < _listeners.Count; i++)
            {
                if (_listeners[i] is IGameLoseListener loseListeners) 
                    loseListeners.OnLoseGame();
            }

            _gameState = GameState.LOSE;
            Debug.Log("Lose");
        }
    }
}