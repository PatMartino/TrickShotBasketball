using System.Collections.Generic;
using Enums;
using UnityEngine;
using Signals;

namespace Trajectory
{
    public class DrawTrajectory : MonoBehaviour
    {
        #region Serialized Field
        
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] [Range(3, 90)] private int lineSegmentCount = 20;
        [SerializeField] [Range(0.1f, 1f)] private float showPercentage = 0.5f;
        
        #endregion

        #region Private Field

        private int _linePointCount;
        private List<Vector3> _linePoints = new List<Vector3>();
        
        #endregion

        #region OnEnable, Start, OnDisable

        private void OnEnable()
        {
            SubscribeEvents();
        }
        
        private void Start()
        {
            _linePointCount = Mathf.RoundToInt(lineSegmentCount * showPercentage);
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion

        #region Private Functions
        
        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.OnUpdateTrajectory += OnUpdateTrajectory;
            CoreGameSignals.Instance.OnHidingLine += OnHidingLine;
        }
        
        private void OnUpdateTrajectory(Vector3 forceVector, Rigidbody rigidBody, Vector3 startingPoint)
        {
            if(CoreGameSignals.Instance.OnGettingGameState?.Invoke()!=GameStates.Game)    
                return;
            Vector3 velocity = (forceVector / rigidBody.mass) * Time.fixedDeltaTime;

            float flightDuration = (2 * velocity.y) / Physics.gravity.y;
            float stepTime = flightDuration / lineSegmentCount;
            _linePoints.Clear();
            _linePoints.Add(startingPoint);
            for (int i = 0; i < _linePointCount; i++)
            {
                float stepTimePassed = stepTime * (i + 1);
                Vector3 movementVector = new Vector3(
                    velocity.x * stepTimePassed,
                    velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                    velocity.z * stepTimePassed);
                Vector3 newPointOnLine = -movementVector + startingPoint;
                _linePoints.Add(newPointOnLine);
            }

            lineRenderer.positionCount = _linePoints.Count;
            lineRenderer.SetPositions(_linePoints.ToArray());
        }

        private void OnHidingLine()
        {
            lineRenderer.positionCount = 0;
        }
        
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.OnUpdateTrajectory -= OnUpdateTrajectory;
            CoreGameSignals.Instance.OnHidingLine -= OnHidingLine;
        }
        
        #endregion

    }
}
