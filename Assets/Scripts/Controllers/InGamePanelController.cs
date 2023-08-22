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

        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI bounceText;

        #endregion

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
            UISignals.Instance.OnSettingBounceText += OnSettingBounceText;
            UISignals.Instance.OnSettingLevelText += OnSettingLevelText;
        }

        private void OnSettingLevelText()
        {
            int level = CoreGameSignals.Instance.OnGettingLevelID() + 1;
            levelText.text = "Level " + level;
            Debug.Log("Level: "+(int)CoreGameSignals.Instance.OnGettingLevelID());
        }

        private void OnSettingBounceText()
        {
            bounceText.text = "Bounce " +((int)CoreGameSignals.Instance.OnGettingBounceData()-(int)CoreGameSignals.Instance.OnGettingBounceLeft());
        }
        
        private void UnSubscribeEvents()
        {
            UISignals.Instance.OnSettingBounceText -= OnSettingBounceText;
            UISignals.Instance.OnSettingLevelText -= OnSettingLevelText;
        }
        
        #endregion
    }
}
