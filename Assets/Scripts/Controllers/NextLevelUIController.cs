using System;
using UnityEngine;
using Signals;

namespace Controllers
{
    public class NextLevelUIController : MonoBehaviour
    {
        [Header("CheckPointUI")] 
        [SerializeField] private Transform checkPoint0;
        [SerializeField] private Transform checkPoint1;
        [SerializeField] private Transform checkPoint2;
        [SerializeField] private Transform checkPoint3;

        private void OnEnable()
        {
            SetCheckPointUI();
        }

        private void SetCheckPointUI()
        {
            checkPoint0.gameObject.SetActive(false);
            checkPoint1.gameObject.SetActive(false);
            checkPoint2.gameObject.SetActive(false);
            checkPoint3.gameObject.SetActive(false);
            if (CoreGameSignals.Instance.OnGettingLevelID() % 3 == 0)
            {
                checkPoint1.gameObject.SetActive(true);
            }
            else if (CoreGameSignals.Instance.OnGettingLevelID() % 3 == 1)
            {
                checkPoint2.gameObject.SetActive(true);
            }
            else if (CoreGameSignals.Instance.OnGettingLevelID() % 3 == 2)
            {
                checkPoint3.gameObject.SetActive(true);
            }
        }
    }
}
