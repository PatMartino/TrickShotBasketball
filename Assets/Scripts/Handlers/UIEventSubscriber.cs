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

        #endregion
        
        #region OnEnable, Start, OnDisable

        private void Awake()
        {
            _button = GetComponent<Button>();
        }
        
        private void OnEnable()
        {
            SubscribeEvents();
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
            }
        }

        #endregion
    }
}
