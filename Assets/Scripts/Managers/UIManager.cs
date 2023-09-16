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
            if (state != UIStates.Store && state !=UIStates.StoreButton)
            {
                Debug.Log(state);
                UIDestroyer();
            }


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
                    canvas.GetChild(0).gameObject.SetActive(false);
                    Instantiate(Resources.Load<GameObject>("UI/Store"), canvas, false);
                    break;
                case UIStates.StoreButton:
                    SaveSignals.Instance.OnSavingBallStore?.Invoke();
                    canvas.GetChild(0).gameObject.SetActive(true);
                    Destroy(canvas.GetChild(1).gameObject);
                    break;
                case UIStates.ExtraHealth:
                    Instantiate(Resources.Load<GameObject>("UI/ExtraHealth"), canvas, false);
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
