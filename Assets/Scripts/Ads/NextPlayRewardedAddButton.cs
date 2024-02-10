using System;
using Signals;
using UnityEngine;
using Enums;

namespace Ads
{
    public class NextPlayRewardedAddButton : MonoBehaviour
    {
            [SerializeField] private RewardAdButton type;
            
        private void Awake()
        {
            //IronSource.Agent.init ("1bfd4b96d");
            //IronSource.Agent.validateIntegration();
        }

        private void OnEnable()
        {
            IronSourceRewardedVideoEvents.onAdOpenedEvent += RewardedVideoOnAdOpenedEvent;
            IronSourceRewardedVideoEvents.onAdClosedEvent += RewardedVideoOnAdClosedEvent;
            IronSourceRewardedVideoEvents.onAdAvailableEvent += RewardedVideoOnAdAvailable;
            IronSourceRewardedVideoEvents.onAdUnavailableEvent += RewardedVideoOnAdUnavailable;
            IronSourceRewardedVideoEvents.onAdShowFailedEvent += RewardedVideoOnAdShowFailedEvent;
            IronSourceRewardedVideoEvents.onAdRewardedEvent += RewardedVideoOnAdRewardedEvent;
            IronSourceRewardedVideoEvents.onAdClickedEvent += RewardedVideoOnAdClickedEvent;

            //dSignals.Instance.OnShowRewardedAd += OnShowRewardedAd;
        }
        
        public void OnShowRewardedAd()
        {
                if (IronSource.Agent.isRewardedVideoAvailable())
                { 
                        IronSource.Agent.showRewardedVideo();  
                }
                else
                {
                        Debug.Log("No Ad");
                }
        }
        
        void RewardedVideoOnAdAvailable(IronSourceAdInfo adInfo) {
        }
// Indicates that no ads are available to be displayed
// This replaces the RewardedVideoAvailabilityChangedEvent(false) event
        void RewardedVideoOnAdUnavailable() {
        }
// The Rewarded Video ad view has opened. Your activity will loose focus.
        void RewardedVideoOnAdOpenedEvent(IronSourceAdInfo adInfo){
        }
// The Rewarded Video ad view is about to be closed. Your activity will regain its focus.
        void RewardedVideoOnAdClosedEvent(IronSourceAdInfo adInfo){
        }
// The user completed to watch the video, and should be rewarded.
// The placement parameter will include the reward data.
// When using server-to-server callbacks, you may ignore this event and wait for the ironSource server callback.
        void RewardedVideoOnAdRewardedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo){
                
                if (type==RewardAdButton.DoublePoint)
                {
                        CoinSignals.Instance.OnSetCoin?.Invoke(CoinOperations.Gain,100);
                }
                else
                {
                        HealthSignals.Instance.OnSetHealth?.Invoke(CoinOperations.Gain,5);
                        CoreGameSignals.Instance.OnContinueWithExtraHealth?.Invoke();
                }
                
        }
// The rewarded video ad was failed to show.
        void RewardedVideoOnAdShowFailedEvent(IronSourceError error, IronSourceAdInfo adInfo){
        }
// Invoked when the video ad was clicked.
// This callback is not supported by all networks, and we recommend using it only if
// it’s supported by all networks you included in your build.
        void RewardedVideoOnAdClickedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo){
        }
        private void OnDisable()
        {
                IronSourceRewardedVideoEvents.onAdOpenedEvent -= RewardedVideoOnAdOpenedEvent;
                IronSourceRewardedVideoEvents.onAdClosedEvent -= RewardedVideoOnAdClosedEvent;
                IronSourceRewardedVideoEvents.onAdAvailableEvent -= RewardedVideoOnAdAvailable;
                IronSourceRewardedVideoEvents.onAdUnavailableEvent -= RewardedVideoOnAdUnavailable;
                IronSourceRewardedVideoEvents.onAdShowFailedEvent -= RewardedVideoOnAdShowFailedEvent;
                IronSourceRewardedVideoEvents.onAdRewardedEvent -= RewardedVideoOnAdRewardedEvent;
                IronSourceRewardedVideoEvents.onAdClickedEvent -= RewardedVideoOnAdClickedEvent;

                //dSignals.Instance.OnShowRewardedAd += OnShowRewardedAd;
        }
    }
}