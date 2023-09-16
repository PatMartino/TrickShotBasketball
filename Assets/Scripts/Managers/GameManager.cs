using System;
using UnityEngine;
using Enums;
using Signals;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
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
        }
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.OnChangeGameState -= OnChangeGameState;
            CoreGameSignals.Instance.OnPausingGame -= OnPausingGame;
            CoreGameSignals.Instance.OnResumingGame -= OnResumingGame;
            CoreGameSignals.Instance.OnGettingGameState -= OnGettingGameState;
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

        #endregion
    }
}
