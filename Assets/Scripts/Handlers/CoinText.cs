using Signals;
using UnityEngine;
using TMPro;

namespace Handlers
{
    public class CoinText : MonoBehaviour
    {
        #region Private Field

        private TextMeshProUGUI _coinText;

        #endregion

        #region Awake, OnEnable

        private void Awake()
        {
            _coinText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            SubscribeEvents();
            _coinText.text = CoinSignals.Instance.OnGetCoin.Invoke().ToString();
        }

        #endregion

        #region Private Functions

        private void SubscribeEvents()
        {
            UISignals.Instance.OnSetCoinText += OnSetCoinText;
        }

        private void OnSetCoinText()
        {
            _coinText.text = CoinSignals.Instance.OnGetCoin.Invoke().ToString();
        }

        #endregion
    }
}
