/*using System;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using Signals;

namespace Ads
{
    public class BannerAdExample : MonoBehaviour
    {
        [SerializeField] BannerPosition _bannerPosition = BannerPosition.TOP_CENTER;
 
        [SerializeField] string _androidAdUnitId = "Banner_Android";
        [SerializeField] string _iOSAdUnitId = "Banner_iOS";
        string _adUnitId = null; // This will remain null for unsupported platforms.

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        void Start()
        {
            // Get the Ad Unit ID for the current platform:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
            _adUnitId = _androidAdUnitId;
#endif

 
            // Set the banner position:
            Advertisement.Banner.SetPosition(_bannerPosition);
        }
 
        // Implement a method to call when the Load Banner button is clicked:
        
        private void SubscribeEvents()
        {
            AdSignals.Instance.OnLoadBanner += LoadBanner;
            AdSignals.Instance.OnShowingBanner += ShowBannerAd;
            //AdSignals.Instance.OnHideBanner += OnHideBannerAd;
        }
        
        public void LoadBanner()
        {
            if (CoreGameSignals.Instance.OnGetGamePass()) return;
            Debug.Log("LoadBanner");
            // Set up options to notify the SDK of load events:
            BannerLoadOptions options = new BannerLoadOptions
            {
                loadCallback = OnBannerLoaded,
                errorCallback = OnBannerError
            };
 
            // Load the Ad Unit with banner content:
            Advertisement.Banner.Load(_adUnitId, options);

        }
 
        // Implement code to execute when the loadCallback event triggers:
        void OnBannerLoaded()
        {
            
 
    
        }
 
        // Implement code to execute when the load errorCallback event triggers:
        void OnBannerError(string message)
        {
            Debug.Log($"Banner Error: {message}");
            // Optionally execute additional code, such as attempting to load another ad.
        }
 
        // Implement a method to call when the Show Banner button is clicked:
        void ShowBannerAd()
        {
            if (CoreGameSignals.Instance.OnGetGamePass()) return;
            Debug.Log("Banner Showing");
            // Set up options to notify the SDK of show events:
            BannerOptions options = new BannerOptions
            {
                clickCallback = OnBannerClicked,
                hideCallback = OnBannerHidden,
                showCallback = OnBannerShown
            };
 
            // Show the loaded Banner Ad Unit:
            Advertisement.Banner.Show(_adUnitId, options);
        }
 
        // Implement a method to call when the Hide Banner button is clicked:
        void OnHideBannerAd()
        {
            // Hide the banner:
            Advertisement.Banner.Hide();
        }
 
        void OnBannerClicked() { }
        void OnBannerShown() { }
        void OnBannerHidden() { }
        
        private void UnSubscribeEvents()
        {
            AdSignals.Instance.OnLoadBanner -= LoadBanner;
            AdSignals.Instance.OnShowingBanner -= ShowBannerAd;
            AdSignals.Instance.OnHideBanner -= OnHideBannerAd;
        }
 
        
    }
}*/