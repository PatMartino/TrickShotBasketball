using UnityEngine;

namespace GameObjects
{
    public class Moving : MonoBehaviour
    {
        public Transform pointA;
        public Transform pointB;
        public float speed = 2.0f;
    
        private Transform currentTarget;
    
        private void Start()
        {
            currentTarget = pointB;
        }
    
        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, currentTarget.position) < 0.01f)
            {
                currentTarget = (currentTarget == pointA) ? pointB : pointA;
            }
        }
    }
}
