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
            if (state != UIStates.Store && state !=UIStates.StoreButton && state!=UIStates.IAPStore && state!=UIStates.IAPStoreBackButton && state!=UIStates.HealthTutorial
                && state!=UIStates.HealthTutorialBack && state!=UIStates.BounceTutorial && state!=UIStates.BounceTutorialBack && state!=UIStates.HandUI)
            {
                Debug.Log(state);
                UIDestroyer();
            }


            switch (state)
            {
                case UIStates.MainMenuUI:
                    Instantiate(Resources.Load<GameObject>("UI/MainMenuUINew"), canvas, false);
                    break;
                case UIStates.InGameUI:
                    UIDestroyer();
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
                case UIStates.IAPStore:
                    canvas.GetChild(0).gameObject.SetActive(false);
                    Instantiate(Resources.Load<GameObject>("UI/IAPStore"), canvas, false);
                    break;
                case UIStates.IAPStoreBackButton:
                    canvas.GetChild(0).gameObject.SetActive(true);
                    Destroy(canvas.GetChild(1).gameObject);
                    break;
                case UIStates.HealthTutorial:
                    Instantiate(Resources.Load<GameObject>("UI/HealthTutorial"), canvas, false);
                    break;
                case UIStates.HealthTutorialBack:
                    Destroy(canvas.GetChild(1).gameObject);
                    Instantiate(Resources.Load<GameObject>("UI/BounceTutorial"), canvas, false);
                    break;
                case UIStates.BounceTutorial:
                    Instantiate(Resources.Load<GameObject>("UI/BounceTutorial"), canvas, false);
                    break;
                case UIStates.BounceTutorialBack:
                    Destroy(canvas.GetChild(1).gameObject);
                    break;
                case UIStates.HandUI:
                    Instantiate(Resources.Load<GameObject>("UI/HandUI"), canvas, false);
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
