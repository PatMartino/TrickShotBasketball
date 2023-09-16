using System;
using UnityEngine;
using Enums;
using UnityEngine.EventSystems;

namespace GameObjects
{
    public class Cars : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private CarsType type;
        [SerializeField] private Transform carSpawnPointRight;
        [SerializeField] private Transform carSpawnPointLeft;

        #endregion

        #region Update

        private void Update()
        {
            Moving();
        }

        #endregion

        #region Private Functions

        private void Moving()
        {
           transform.Translate(0,0,4*Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (type)
            {
                case CarsType.Right:
                    if (other.gameObject.CompareTag("CarRight"))
                    {
                        transform.position = carSpawnPointRight.position;
                    }
                    break;
                case CarsType.Left:
                    if (other.gameObject.CompareTag("CarLeft"))
                    {
                        transform.position = carSpawnPointLeft.position;
                    }
                    break;

            }
        }

        #endregion
    }
}
