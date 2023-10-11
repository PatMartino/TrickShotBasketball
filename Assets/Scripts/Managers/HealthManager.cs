using Signals;
using UnityEngine;
using Enums;

namespace Managers
{
    public class HealthManager : MonoBehaviour
    {
        #region Private Fields

        private int _health;
        private int _checkpoint;

        #endregion

        #region OnEnable, OnDisable

        private void OnEnable()
        {
            SubscribeEvents();
            Load();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion
        
        #region Private Functions

        private void SubscribeEvents()
        {
            HealthSignals.Instance.OnGetHealth += OnGetHealth;
            HealthSignals.Instance.OnSetHealth += OnSetHealth;
            HealthSignals.Instance.OnGetCheckPoint += OnGetCheckPoint;
            HealthSignals.Instance.OnSetCheckPoint += OnSetCheckPoint;
            HealthSignals.Instance.OnCheckIsACheckpoint += OnCheckIsACheckpoint;
        }

        private int OnGetHealth()
        {
            return _health;
        }

        private void OnSetHealth(CoinOperations type, int num)
        {
            switch (type)
            {
                case CoinOperations.Gain:
                    if (!CoreGameSignals.Instance.OnGetGamePass())
                    {
                        _health += num;
                    }
                    else
                    {
                        _health = 9999;
                    }
                    
                    Debug.Log("New Health: " + _health);
                    break;
                case CoinOperations.Lose:
                    if (!CoreGameSignals.Instance.OnGetGamePass())
                    {
                        _health -= num;
                        if (_health<0)
                        {
                            _health = 0;
                        }
                    }
                    else
                    {
                        _health = 9999;
                    }
                    UISignals.Instance.OnSetHealthTest.Invoke();
                    break;
            }
            SaveHealth();
        }

        private int OnGetCheckPoint()
        {
            return _checkpoint;
        }

        private void OnSetCheckPoint()
        {
            _checkpoint = CoreGameSignals.Instance.OnGettingLevelID.Invoke();
            SaveCheckPoint();
            if (!CoreGameSignals.Instance.OnGetGamePass())
            {
                _health = 9;
            }
            else
            {
                _health = 9999;
            }
            
            Debug.Log("New Health: "+ _health);
        }

        private void SaveHealth()
        {
            ES3.Save("Health", _health);
            Debug.Log("Saved Health");
        }

        private void SaveCheckPoint()
        {
            ES3.Save("CheckPoint", _checkpoint);
        }

        private void Load()
        {
            _health = ES3.KeyExists("Health") ? ES3.Load<int>("Health") : 9;
            _checkpoint = ES3.KeyExists("CheckPoint") ? ES3.Load<int>("CheckPoint") : 1;
        }

        private void OnCheckIsACheckpoint()
        {
            if (CoreGameSignals.Instance.OnGettingLevelID.Invoke() % 3 == 0)
            {
                OnSetCheckPoint();
            }
        }
        
        private void UnSubscribeEvents()
        {
            HealthSignals.Instance.OnGetHealth -= OnGetHealth;
            HealthSignals.Instance.OnSetHealth -= OnSetHealth;
            HealthSignals.Instance.OnGetCheckPoint -= OnGetCheckPoint;
            HealthSignals.Instance.OnSetCheckPoint -= OnSetCheckPoint;
            HealthSignals.Instance.OnCheckIsACheckpoint -= OnCheckIsACheckpoint;
        }

        #endregion
    }
}
