using System;
using Signals;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers
{
    public class InGamePanelController : MonoBehaviour
    {
        #region Serialized Field
        
        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI bounceText;
        [SerializeField] private TextMeshProUGUI healthText;

        [Header("CheckPointUI")] 
        [SerializeField] private Transform checkPoint0;
        [SerializeField] private Transform checkPoint1;
        [SerializeField] private Transform checkPoint2;
        [SerializeField] private Transform checkPoint3;

        #endregion

        #region OnEnable, OnDisable
        
        private void OnEnable()
        {
            SubscribeEvents();
            OnSetHealthText();
            OnSetCheckPointUI();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion

        #region Private Functions
        
        private void SubscribeEvents()
        {
            UISignals.Instance.OnSettingBounceText += OnSettingBounceText;
            UISignals.Instance.OnSettingLevelText += OnSettingLevelText;
            UISignals.Instance.OnSetHealthTest += OnSetHealthText;
            UISignals.Instance.OnSetCheckPointUI += OnSetCheckPointUI;
        }

        private void OnSettingLevelText()
        {
            int level = CoreGameSignals.Instance.OnGettingLevelID();
            levelText.text = "Level " + level;
            Debug.Log("Level: "+(int)CoreGameSignals.Instance.OnGettingLevelID());
        }

        private void OnSettingBounceText()
        {
            bounceText.text = ((int)CoreGameSignals.Instance.OnGettingBounceData()-(int)CoreGameSignals.Instance.OnGettingBounceLeft()).ToString();
        }

        private void OnSetHealthText()
        {
            healthText.text = HealthSignals.Instance.OnGetHealth().ToString();
        }

        private void OnSetCheckPointUI()
        {
            checkPoint0.gameObject.SetActive(false);
            checkPoint1.gameObject.SetActive(false);
            checkPoint2.gameObject.SetActive(false);
            checkPoint3.gameObject.SetActive(false);
            if (CoreGameSignals.Instance.OnGettingLevelID() % 3 == 0)
            {
                checkPoint0.gameObject.SetActive(true);
            }
            else if (CoreGameSignals.Instance.OnGettingLevelID() % 3 == 1)
            {
                checkPoint1.gameObject.SetActive(true);
            }
            else if (CoreGameSignals.Instance.OnGettingLevelID() % 3 == 2)
            {
                checkPoint2.gameObject.SetActive(true);
            }
        }
        
        private void UnSubscribeEvents()
        {
            UISignals.Instance.OnSettingBounceText -= OnSettingBounceText;
            UISignals.Instance.OnSettingLevelText -= OnSettingLevelText;
            UISignals.Instance.OnSetHealthTest -= OnSetHealthText;
            UISignals.Instance.OnSetCheckPointUI -= OnSetCheckPointUI;
        }
        
        #endregion
    }
}
