using System;
using Enums;
using UnityEngine;
using Signals;

namespace Managers
{
    public class CoinManager : MonoBehaviour
    {
        #region private Field

        private int _coin=0;
        private bool _isActive=false;

        #endregion

        #region OnEnable, OnDisable, Awake

        private void Awake()
        {
            if (ES3.KeyExists("Coin"))
            {
                _coin = ES3.Load<int>("Coin");
            }
            
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

        #region Private Region

        private void SubscribeEvents()
        {
            CoinSignals.Instance.OnGetCoin += OnGetCoin;
            CoinSignals.Instance.OnSetCoin += OnSetCoin;
        }

        private int OnGetCoin()
        {
            return _coin;
        }

        private void OnSetCoin(CoinOperations op, int value)
        {
            if(_isActive) return;
            switch (op)
            {
                case CoinOperations.Gain:
                    _coin += value;
                    break;
                case CoinOperations.Lose:
                    _coin -= value;
                    break;
            }
            UISignals.Instance.OnSetCoinText?.Invoke();
            ES3.Save("Coin",_coin);

            _isActive = false;
        }
        
        private void UnSubscribeEvents()
        {
            CoinSignals.Instance.OnGetCoin -= OnGetCoin;
            CoinSignals.Instance.OnSetCoin -= OnSetCoin;
        }
        
        

        #endregion
    }
}
