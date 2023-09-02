using Signals;
using UnityEditor;
using UnityEngine;

namespace Ball
{
    public class SwitchBall : MonoBehaviour
    {
        #region Serialized Field

        

        #endregion
        
        #region Private Field

        private GameObject _ball;

        #endregion

        #region OnEnable, Start, OnDisable

        private void OnEnable()
        {
            SubscribeEvents();
        }

        #endregion

        #region Private Functions

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.OnSelectBall += OnSelectBall;
            CoreGameSignals.Instance.OnGettingBall += OnGettingBall;
        }

        private void OnSelectBall(int num)
        {
            Debug.Log("Select Ball"+ num);
            _ball = Resources.Load<GameObject>($"Prefabs/BallPrefabs/Ball{num}");
        }

        private GameObject OnGettingBall()
        {
            return _ball;
        }


        #endregion
    }
}
