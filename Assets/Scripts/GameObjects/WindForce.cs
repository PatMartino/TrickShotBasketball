using UnityEngine;

namespace GameObjects
{
    public class WindForce : MonoBehaviour
    {
        #region Serialized Field

        [SerializeField]
        private float windForce=0f;

        #endregion

        #region Private Functions

        private void OnTriggerStay(Collider other)
        {
            if(!other.gameObject.CompareTag("Ball"))return;
            var hitObj = other.gameObject;
            if (hitObj == null) return;
            var rb = hitObj.GetComponent<Rigidbody>();
            var dir = transform.up;
            rb.AddForce(dir * windForce);
        }

        #endregion
    }
}
