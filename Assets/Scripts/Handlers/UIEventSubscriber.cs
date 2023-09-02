using UnityEngine;
using Enums;
using Signals;
using UnityEngine.UI;

namespace Handlers
{
    public class UIEventSubscriber : MonoBehaviour
    {
        #region Serialized Field

        [SerializeField] private UIEventSubscriptionTypes type;

        #endregion
        
        #region Private Field

        private Button _button;
        private bool _isInitialized = false;

        #endregion
        
        #region OnEnable, Start, OnDisable

        private void Awake()
        {
            _button = GetComponent<Button>();
        }
        
        private void OnEnable()
        {
            if (!_isInitialized)
            {
                SubscribeEvents();
                _isInitialized = true;
            }
        }

        #endregion
        
        #region Private Functions

        private void SubscribeEvents()
        {
            switch (type)
            {
                case UIEventSubscriptionTypes.OnPlay:
                {
                    _button.onClick.AddListener(() => CoreGameSignals.Instance.OnPlay());
                    break;
                }
                case UIEventSubscriptionTypes.OnNextLevel:
                {
                    _button.onClick.AddListener(CoreGameSignals.Instance.OnNextLevel);
                    break;
                }
                case UIEventSubscriptionTypes.OnBuyingRareBall:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnBuyingBall.Invoke(BallLevelTypes.Rare));
                    break;
                case UIEventSubscriptionTypes.OnBuyingCommonBall:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnBuyingBall.Invoke(BallLevelTypes.Common));
                    break;
                case UIEventSubscriptionTypes.OnBuyingLegendaryBall:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnBuyingBall.Invoke(BallLevelTypes.Legendary));
                    break;
                case UIEventSubscriptionTypes.OnStore:
                    _button.onClick.AddListener(() =>UISignals.Instance.OnMenuUIManagement.Invoke(UIStates.Store));
                    break;
                case UIEventSubscriptionTypes.StoreButton:
                    _button.onClick.AddListener(() =>UISignals.Instance.OnMenuUIManagement.Invoke(UIStates.StoreButton));
                    break;
            }
        }

        #endregion
    }
}
