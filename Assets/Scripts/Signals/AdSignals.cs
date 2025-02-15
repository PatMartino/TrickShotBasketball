﻿using Extensions;
using UnityEngine.Events;

namespace Signals
{
    public class AdSignals : MonoSingleton<AdSignals>
    {
        public UnityAction OnLoadingAd = delegate {  };
        public UnityAction OnShowingAd = delegate {  };
        public UnityAction OnShowingBanner = delegate {  };
        public UnityAction OnLoadBanner = delegate {  };
        public UnityAction OnHideBanner = delegate {  };
        public UnityAction OnLoadInterstitialAds = delegate {  };
        public UnityAction OnShowInterstitialAds = delegate {  };
        public UnityAction OnShowRewardedAd = delegate {  };
    }
}