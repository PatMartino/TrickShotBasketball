using System;
using Signals;
using UnityEngine;

namespace Handlers
{
    public class SwitchBallLevel : MonoBehaviour
    {
        #region SerializedField

        [SerializeField] private GameObject common;
        [SerializeField] private GameObject rare;
        [SerializeField] private GameObject legendary;

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

        #region Private Function

        private void SubscribeEvents()
        {
            UISignals.Instance.OnCommon += OnCommon;
            UISignals.Instance.OnRare += OnRare;
            UISignals.Instance.OnLegendary += OnLegendary;
        }

        private void OnCommon()
        {
            rare.SetActive(false);
            legendary.SetActive(false);
            common.SetActive(true);
        }
        private void OnRare()
        {
            rare.SetActive(true);
            legendary.SetActive(false);
            common.SetActive(false);
        }
        private void OnLegendary()
        {
            rare.SetActive(false);
            legendary.SetActive(true);
            common.SetActive(false);
        }

        private void UnSubscribeEvents()
        {
            UISignals.Instance.OnCommon -= OnCommon;
            UISignals.Instance.OnRare -= OnRare;
            UISignals.Instance.OnLegendary -= OnLegendary;
        }

        #endregion
    }
}
