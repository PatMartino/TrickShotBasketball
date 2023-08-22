using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    public class ObjectActivator : MonoBehaviour
    {
        [System.Serializable]
        public class ObjectToggleInfo
        {
            public GameObject gameObject;
            public float activeTimeInterval = 1.0f;
            public float inActiveTimeInterval = 1.0f;
        }

        public List<ObjectToggleInfo> objectsToToggle;

        private void Start()
        {
            foreach (ObjectToggleInfo info in objectsToToggle)
            {
                ToggleObjectAsync(info);
            }
        }

        private async void ToggleObjectAsync(ObjectToggleInfo info)
        {
            while (true)
            {
                ToggleObjectComponents(info.gameObject, true); // Etkinleştir
                await Task.Delay((int)(info.activeTimeInterval * 1000)); // Süre boyunca beklet

                ToggleObjectComponents(info.gameObject, false); // Devre dışı bırak
                await Task.Delay((int)(info.inActiveTimeInterval * 1000)); // 1 saniye boyunca beklet
            }
        }

        private void ToggleObjectComponents(GameObject obj, bool state)
        {
            if (obj == null) return;
            Collider collider = obj.GetComponent<Collider>();
            MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
            if (collider != null)
            {
                collider.enabled = state;
            }

            if (meshRenderer != null)
            {
                meshRenderer.enabled = state;
            }
        }
    }
}
