using System.Collections.Generic;
using UnityEngine;
using Signals;

namespace GameObjects
{
    public class NetCloth : MonoBehaviour
    {
        #region OnEnable, OnDisable

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
            CoreGameSignals.Instance.OnSetNetClothCollider += OnSetNetClothCollider;
        }

        private void OnSetNetClothCollider()
        {
            Debug.Log("Colliderrrr");
            // "ball" tag'ına sahip objeyi bul.
            GameObject ball = CoreGameSignals.Instance.OnGettingBallHolder.Invoke().GetChild(0).gameObject;
            Debug.Log(ball.name);

            // Objenin SphereCollider'ını bul.
            SphereCollider sphereCollider = ball.GetComponent<SphereCollider>();

            ClothSphereColliderPair[] clothSphereColliders = new ClothSphereColliderPair[1];
            clothSphereColliders[0] = new ClothSphereColliderPair();
            clothSphereColliders[0].first = sphereCollider;;
            GetComponent<Cloth>().sphereColliders = clothSphereColliders;
            /*var sphereCollider = GetComponent<Cloth>().sphereColliders[0];
            var ball = GameObject.FindWithTag("Ball");
            sphereCollider = new ClothSphereColliderPair(ball.GetComponent<SphereCollider>());
            GetComponent<Cloth>().sphereColliders[0] = sphereCollider;*/
        }
        
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.OnSetNetClothCollider -= OnSetNetClothCollider;
        }

        #endregion
    }
}
