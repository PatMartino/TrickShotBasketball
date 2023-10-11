using System;
using UnityEngine;
using Enums;
using Signals;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Private Fields

        private bool _isGamePassActive;

        #endregion
        
        #region Serialized Field

        [SerializeField] private GameStates states;

        #endregion

        #region Awake, OnEnable, OnDisable

        private void Awake()
        {
            Time.timeScale = 1.4f;
            
        }

        private void OnEnable()
        {
            if (ES3.KeyExists("GamePass"))
            {
                _isGamePassActive = ES3.Load<bool>("GamePass");
            }
            
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion

        #region Private Functions
        
        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.OnChangeGameState += OnChangeGameState;
            CoreGameSignals.Instance.OnPausingGame += OnPausingGame;
            CoreGameSignals.Instance.OnResumingGame += OnResumingGame;
            CoreGameSignals.Instance.OnGettingGameState += OnGettingGameState;
            CoreGameSignals.Instance.OnGetGamePass += OnGetGamePass;
            CoreGameSignals.Instance.OnGamePassActivated += OnGamePassActivated;
            CoreGameSignals.Instance.OnGamePassDeactivated += OnGamePassDeactivated;
        }
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.OnChangeGameState -= OnChangeGameState;
            CoreGameSignals.Instance.OnPausingGame -= OnPausingGame;
            CoreGameSignals.Instance.OnResumingGame -= OnResumingGame;
            CoreGameSignals.Instance.OnGettingGameState -= OnGettingGameState;
            CoreGameSignals.Instance.OnGetGamePass -= OnGetGamePass;
            CoreGameSignals.Instance.OnGamePassActivated -= OnGamePassActivated;
            CoreGameSignals.Instance.OnGamePassDeactivated -= OnGamePassDeactivated;
        }

        private void OnChangeGameState(GameStates state)
        {
            states = state;
        }

        private GameStates OnGettingGameState()
        {
            return states;
        }

        private void OnPausingGame()
        {
            //OnChangeGameState(GameStates.Pause);
            Time.timeScale = 0;
        }
        private void OnResumingGame()
        {
            OnChangeGameState(GameStates.Game);
            Time.timeScale = 1.4f;
        }

        private bool OnGetGamePass()
        {
            return _isGamePassActive;
        }


        private void OnGamePassActivated()
        {
            _isGamePassActive = true;
            SaveGamePass();
            Debug.Log(_isGamePassActive);
        }

        private void OnGamePassDeactivated()
        {
            _isGamePassActive = false;
            SaveGamePass();
        }

        private void SaveGamePass()
        {
            ES3.Save("GamePass",_isGamePassActive);
        }

        #endregion
    }
}
