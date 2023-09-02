using System;
using Signals;
using UnityEngine;
using Enums;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Serialized Field

        [SerializeField] private Transform canvas;

        #endregion

        #region Private Field



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
            UISignals.Instance.OnMenuUIManagement += OnMenuUIManagement;
        }

        private void OnMenuUIManagement(UIStates state)
        {
            UIDestroyer();

            switch (state)
            {
                case UIStates.MainMenuUI:
                    Instantiate(Resources.Load<GameObject>("UI/MainMenuUI"), canvas, false);
                    break;
                case UIStates.InGameUI:
                    Instantiate(Resources.Load<GameObject>("UI/InGameUI"), canvas, false);
                    UISignals.Instance.OnSettingLevelText?.Invoke();
                    UISignals.Instance.OnSettingBounceText?.Invoke();
                    break;
                case UIStates.NextLevelUI:
                    Instantiate(Resources.Load<GameObject>("UI/NextLevelUI"), canvas, false);
                    break;
                case UIStates.Store:
                    Debug.Log("Obaaaaa");
                    Instantiate(Resources.Load<GameObject>("UI/Store"), canvas, false);
                    break;
                case UIStates.StoreButton:
                    Instantiate(Resources.Load<GameObject>("UI/StoreButton"), canvas, false);
                    break;
            }
            
        }

        private void UIDestroyer()
        {
            Destroy(canvas.GetChild(0).gameObject);
        }
        
        private void UnSubscribeEvents()
        {
            UISignals.Instance.OnMenuUIManagement -= OnMenuUIManagement;
        }

        #endregion
        
    }
}
