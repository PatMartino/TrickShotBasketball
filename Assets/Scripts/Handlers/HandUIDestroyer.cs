using System;
using UnityEngine;

namespace Handlers
{
    public class HandUIDestroyer : MonoBehaviour
    {
        private void OnEnable()
        {
            Destroy(gameObject,4);
        }
    }
}
