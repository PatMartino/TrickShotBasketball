using System.Collections;
using Signals;
using UnityEngine;
namespace Ads
{
    public class LevelPlayAds : MonoBehaviour
    {
            private byte _adCount=1;
        private void Awake()
        {
            IronSource.Agent.init ("1bfd4b96d");
            IronSource.Agent.validateIntegration();
            IronSource.Agent.setConsent(true);
        }

        private void OnEnable()
        {
            IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;
            //Add AdInfo Interstitial Events
            IronSourceInterstitialEvents.onAdReadyEvent += InterstitialOnAdReadyEvent;
            IronSourceInterstitialEvents.onAdLoadFailedEvent += InterstitialOnAdLoadFailed;
            IronSourceInterstitialEvents.onAdOpenedEvent += InterstitialOnAdOpenedEvent;
            IronSourceInterstitialEvents.onAdClickedEvent += InterstitialOnAdClickedEvent;
            IronSourceInterstitialEvents.onAdShowSucceededEvent += InterstitialOnAdShowSucceededEvent;
            IronSourceInterstitialEvents.onAdShowFailedEvent += InterstitialOnAdShowFailedEvent;
            IronSourceInterstitialEvents.onAdClosedEvent += InterstitialOnAdClosedEvent;

            AdSignals.Instance.OnLoadInterstitialAds += OnLoadInterstitialAds;
            AdSignals.Instance.OnShowInterstitialAds += OnShowInterstitialAds;

        }

        void OnApplicationPause(bool isPaused) {                 
            IronSource.Agent.onApplicationPause(isPaused);
        }
        
        
        private void SdkInitializationCompletedEvent(){}

        private void OnLoadInterstitialAds()
        {
            //IronSource.Agent.loadInterstitial();
        }

        private void OnShowInterstitialAds()
        {
                if (_adCount % 5 == 0 && !CoreGameSignals.Instance.OnGetGamePass())
                {
                        
                        if (IronSource.Agent.isInterstitialReady())
                        {
                                IronSource.Agent.showInterstitial();
                                _adCount = 1;
                        }
                        else
                        {
                                Debug.LogWarning("No normal Ad");
                                Debug.Log("OBAAAAAA");
                        }   
                }
                else if (_adCount % 4 == 0 && !CoreGameSignals.Instance.OnGetGamePass())
                {
                        IronSource.Agent.loadInterstitial();
                        _adCount++;
                        Debug.Log("adcount: "+_adCount);
                }
                else
                {
                        _adCount++;
                        Debug.Log("adcount: "+_adCount);
                }
                
        }
        
        
        /************* Interstitial AdInfo Delegates *************/
// Invoked when the interstitial ad was loaded succesfully.
        void InterstitialOnAdReadyEvent(IronSourceAdInfo adInfo) {
        }
// Invoked when the initialization process has failed.
        void InterstitialOnAdLoadFailed(IronSourceError ironSourceError) {
        }
// Invoked when the Interstitial Ad Unit has opened. This is the impression indication. 
        void InterstitialOnAdOpenedEvent(IronSourceAdInfo adInfo) {
        }
// Invoked when end user clicked on the interstitial ad
        void InterstitialOnAdClickedEvent(IronSourceAdInfo adInfo) {
        }
// Invoked when the ad failed to show.
        void InterstitialOnAdShowFailedEvent(IronSourceError ironSourceError, IronSourceAdInfo adInfo) {
        }
// Invoked when the interstitial ad closed and the user went back to the application screen.
        void InterstitialOnAdClosedEvent(IronSourceAdInfo adInfo) {
        }
// Invoked before the interstitial ad was opened, and before the InterstitialOnAdOpenedEvent is reported.
// This callback is not supported by all networks, and we recommend using it only if  
// it's supported by all networks you included in your build. 
        void InterstitialOnAdShowSucceededEvent(IronSourceAdInfo adInfo) {
        }
        
/************* RewardedVideo AdInfo Delegates *************/
// Indicates that there’s an available ad.
// The adInfo object includes information about the ad that was loaded successfully
// This replaces the RewardedVideoAvailabilityChangedEvent(true) event
            private void OnDisable()
            {
                    IronSourceEvents.onSdkInitializationCompletedEvent -= SdkInitializationCompletedEvent;
                    //Add AdInfo Interstitial Events
                    IronSourceInterstitialEvents.onAdReadyEvent -= InterstitialOnAdReadyEvent;
                    IronSourceInterstitialEvents.onAdLoadFailedEvent -= InterstitialOnAdLoadFailed;
                    IronSourceInterstitialEvents.onAdOpenedEvent -= InterstitialOnAdOpenedEvent;
                    IronSourceInterstitialEvents.onAdClickedEvent -= InterstitialOnAdClickedEvent;
                    IronSourceInterstitialEvents.onAdShowSucceededEvent -= InterstitialOnAdShowSucceededEvent;
                    IronSourceInterstitialEvents.onAdShowFailedEvent -= InterstitialOnAdShowFailedEvent;
                    IronSourceInterstitialEvents.onAdClosedEvent -= InterstitialOnAdClosedEvent;

                    AdSignals.Instance.OnLoadInterstitialAds -= OnLoadInterstitialAds;
                    AdSignals.Instance.OnShowInterstitialAds -= OnShowInterstitialAds;

            }
        



    }
}
