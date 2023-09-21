using UnityEngine;
using UnityEngine.Serialization;

namespace GameObjects
{
    public class Crane : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float minRotation;    
        [SerializeField] private float maxRotation;
        [SerializeField] private bool isTurnRight=true;

        private void Rotation()
        {
            if (isTurnRight)
            {
                Debug.Log(transform.rotation.eulerAngles);
                transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
                if (transform.rotation.eulerAngles.z >=maxRotation&& transform.rotation.eulerAngles.z<=100)
                {
                    Debug.LogWarning("Obaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                    isTurnRight = false;
                }
            }
            else
            {
                Debug.Log(transform.rotation.eulerAngles);
                transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
                if (transform.rotation.eulerAngles.z <=360+minRotation && transform.rotation.eulerAngles.z>=100)
                {
                    isTurnRight = true;
                }
            }
        }
        void Update()
        {

            Rotation();
        }
    }
}
