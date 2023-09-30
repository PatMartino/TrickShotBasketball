using Signals;
using UnityEngine;
using Data;
using Enums;


namespace Controllers
{
    public class BallController : MonoBehaviour
    {
        #region Serialized Field

        [SerializeField] private Transform spawnerPosition;

        #endregion

        #region Private Field
        
        private ushort _bounce=0;
        private Rigidbody _rigidbody;
        //private ushort _levelBounceCount;
        private ushort _levelID;
        private BounceData _bounceData;
        private Quaternion _zeroRotation =new Quaternion(0, 0, 0,0);

        #endregion

        #region Awake, OnEnable, OnDisable

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            SubscribeEvents();
            Init();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion

        #region Private Functions

        private void Init()
        {
            _levelID = CoreGameSignals.Instance.OnGettingLevelID.Invoke();
            _bounceData = (BounceData)Resources.Load($"Data/LevelData/level{_levelID}");
        }
        
        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.OnGettingBounceLeft += OnGettingBounceLeft;
            CoreGameSignals.Instance.OnGettingBounceData += OnGettingBounceData;
            CoreGameSignals.Instance.OnResettingBall += OnResettingBall;
        }

        private void OnCollisionEnter(Collision other)
        {
            SoundSignals.Instance.OnPlayBounceSound.Invoke();
            if (!other.gameObject.CompareTag("Basket") && !other.gameObject.CompareTag("Border"))
            {
                Debug.Log("Carrpppppppp");
                    _bounce++;
                    Debug.Log(_bounce);
                    CheckBounce();
                    UISignals.Instance.OnSettingBounceText?.Invoke();
            }

            else if (other.gameObject.CompareTag("Border"))
            {
                if (!CoreGameSignals.Instance.OnGetIsBasket.Invoke())
                {
                    HealthSignals.Instance.OnSetHealth?.Invoke(CoinOperations.Lose,1);
                    Debug.Log("Health: " + HealthSignals.Instance.OnGetHealth.Invoke());
                    if (HealthSignals.Instance.OnGetHealth.Invoke() <= 0)
                    {
                        UISignals.Instance.OnMenuUIManagement.Invoke(UIStates.ExtraHealth);
                        CoreGameSignals.Instance.OnPausingGame.Invoke();
                    }
                    else
                    {
                        OnResettingBall();
                    }
                }
            }
        }

        private void CheckBounce()
        {
            if (!CoreGameSignals.Instance.OnGetIsBasket.Invoke())
            {
                if (_bounce > _bounceData.MaxBounce)
                {
                    HealthSignals.Instance.OnSetHealth?.Invoke(CoinOperations.Lose,1);
                    Debug.LogWarning("Health: " + HealthSignals.Instance.OnGetHealth.Invoke());
                    if (HealthSignals.Instance.OnGetHealth.Invoke() <= 0)
                    {
                        UISignals.Instance.OnMenuUIManagement.Invoke(UIStates.ExtraHealth);
                        CoreGameSignals.Instance.OnPausingGame.Invoke();
                    }
                    else
                    {
                        
                            CoreGameSignals.Instance.OnResettingBall?.Invoke();
                        
                    }
                }
            }
        }

        private void OnResettingBall()
        {
            _bounce=0;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero; 
            transform.position = CoreGameSignals.Instance.OnGettingBallHolder().position;
            transform.rotation = _zeroRotation;
            CoreGameSignals.Instance.OnTryAgain?.Invoke();
            UISignals.Instance.OnSettingBounceText?.Invoke();
            _rigidbody.isKinematic = true;
        }

        private ushort OnGettingBounceLeft()
        {
            //var bounceLeft = _bounceData.MaxBounce - _bounce;
            return _bounce;
        }

        private ushort OnGettingBounceData()
        {
            return _bounceData.MaxBounce;
        }
        
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.OnGettingBounceLeft -= OnGettingBounceLeft;
            CoreGameSignals.Instance.OnGettingBounceData -= OnGettingBounceData;
            CoreGameSignals.Instance.OnResettingBall -= OnResettingBall;
        }

        #endregion
        
    }
}
