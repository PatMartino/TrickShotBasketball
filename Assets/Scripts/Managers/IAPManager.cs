using Signals;
using UnityEngine;
using Enums;
using UnityEngine.Purchasing;

namespace Managers
{
    public class IAPManager : MonoBehaviour
    {
        private string _coin5000 = "com.hardtimesgamestudios.trickshotbasketball.coin5000";
        private string _noAds = "com.hardtimesgamestudios.trickshotbasketball.noadsinfhealt";

        public void OnPurchaseComplete(Product product)
        {
            if (product.definition.id == _coin5000)
            {
                Debug.Log("Buy");
                CoinSignals.Instance.OnSetCoin.Invoke(CoinOperations.Gain,5000);
            }

            if (product.definition.id == _noAds)
            {
                Debug.Log("Buy");
                CoreGameSignals.Instance.OnGamePassActivated.Invoke();
                AdSignals.Instance.OnHideBanner.Invoke();
            }
            
        }
    }
}
