using Signals;
using UnityEngine;
using Enums;

namespace Ball
{
    public class DragAndShoot : MonoBehaviour
    {
        #region Serialized Field

        [SerializeField]
        private float forceMultiplier = 3;

        #endregion

        #region Private Field

        private Vector3 _mousePressDownPos;
        private Vector3 _mouseReleasePos;
        private Rigidbody _rigidBody;
        private bool _isShoot;

        #endregion

        #region Awake

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }
        
        #endregion

        #region Private Functions

        private void OnMouseDown()
        {
            _mousePressDownPos = Input.mousePosition;
        }

        private void OnMouseUp()
        {
            CoreGameSignals.Instance.OnHidingLine();
            _mouseReleasePos = Input.mousePosition;
            _rigidBody.isKinematic = false;
            Shoot(_mouseReleasePos-_mousePressDownPos);
        }

        private void OnMouseDrag()
        {
            Vector3 forceInit = Input.mousePosition - _mousePressDownPos;
            Vector3 forceV = new Vector3(forceInit.x*1.5f, forceInit.y*2, forceInit.y*1.8f) * -forceMultiplier;
            if (forceV.z > 0)
            {
                CoreGameSignals.Instance.OnUpdateTrajectory(forceV, _rigidBody, transform.position); 
            }
            
        }

        private void Shoot(Vector3 force)
        {
            if(CoreGameSignals.Instance.OnGettingGameState?.Invoke()!=GameStates.Game)    
                return;
        
            _rigidBody.AddForce(new Vector3(force.x*1.5f,force.y*2,force.y*1.8f) * -forceMultiplier);
            CoreGameSignals.Instance.OnChangeGameState?.Invoke(GameStates.Shoot);
        }

        #endregion
        
    }
}
