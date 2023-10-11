using System;
using Signals;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class InterstitialAdExample : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        [SerializeField] string _androidAdUnitId = "Interstitial_Android";
        [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
        string _adUnitId;
        private byte _adCount=1;

        private void Awake()
        {
            // Get the Ad Unit ID for the current platform:
            _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
                ? _iOsAdUnitId
                : _androidAdUnitId;
        }

        private void OnEnable()
        {
            LoadAd();
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void SubscribeEvents()
        {
            AdSignals.Instance.OnShowingAd += ShowAd;
            AdSignals.Instance.OnLoadingAd += LoadAd;
        }

        // Load content to the Ad Unit:
        private void LoadAd()
        {
            // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
            Debug.Log("Loading Ad: " + _adUnitId);
            Advertisement.Load(_adUnitId, this);
        }
 
        // Show the loaded content in the Ad Unit:
        private void ShowAd()
        {
            if (_adCount % 3 == 0 && !CoreGameSignals.Instance.OnGetGamePass())
            {
                Debug.Log("adcount: "+_adCount);
                // Note that if the ad content wasn't previously loaded, this method will fail
                Debug.Log("Showing Ad: " + _adUnitId);
                Advertisement.Show(_adUnitId, this);
                
            }
            _adCount++;
            Debug.Log("adcount: "+_adCount);

            
        }
 
        // Implement Load Listener and Show Listener interface methods: 
        public void OnUnityAdsAdLoaded(string adUnitId)
        {
            // Optionally execute code if the Ad Unit successfully loads content.
        }
 
        public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
        {
            Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
            // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
        }
 
        public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
        {
            Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
            // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
        }
 
        public void OnUnityAdsShowStart(string _adUnitId) { }
        public void OnUnityAdsShowClick(string _adUnitId) { }
        public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState) { }
        
        private void UnSubscribeEvents()
        {
            AdSignals.Instance.OnShowingAd -= ShowAd;
            AdSignals.Instance.OnLoadingAd -= LoadAd;
        }
    }
}
