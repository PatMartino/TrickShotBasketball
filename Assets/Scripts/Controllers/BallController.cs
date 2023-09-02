using Signals;
using UnityEngine;
using Data;


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
            if(other.gameObject.CompareTag("Basket"))
                return;
            _bounce++;
            Debug.Log(_bounce);
            CheckBounce();
            UISignals.Instance.OnSettingBounceText?.Invoke();
        }

        private void CheckBounce()
        {
            if (_bounce > _bounceData.MaxBounce)
            {
                OnResettingBall();
            }
        }

        private void OnResettingBall()
        {
            _bounce=0;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero; 
            transform.position = CoreGameSignals.Instance.OnGettingBallHolder().position;
            CoreGameSignals.Instance.OnTryAgain?.Invoke();
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
