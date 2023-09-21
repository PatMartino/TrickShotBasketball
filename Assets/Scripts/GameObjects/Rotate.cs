using System;
using UnityEngine;

namespace GameObjects
{
    public class Rotate : MonoBehaviour
    {
        #region SerializeFields

        [SerializeField] private float rotationSpeed;

        #endregion

        #region Update

        private void Update()
        {
            Rotation();
        }

        #endregion

        #region Private Functions

        private void Rotation()
        {
            transform.Rotate(rotationSpeed*Time.deltaTime,0,0);
        }

        #endregion
    }
}
