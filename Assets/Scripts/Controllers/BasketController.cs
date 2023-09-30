using System.Threading.Tasks;
using UnityEngine;
using Signals;
using Enums;

namespace Controllers
{
    public class BasketController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (CoreGameSignals.Instance.OnGettingBounceLeft?.Invoke() ==
                CoreGameSignals.Instance.OnGettingBounceData?.Invoke())
            {
                SoundSignals.Instance.OnPlaySwishSound.Invoke();
                WaitForNextLevelMenu();
            }
            else
            {
                if (!CoreGameSignals.Instance.OnGetIsBasket.Invoke())
                {
                    HealthSignals.Instance.OnSetHealth?.Invoke(CoinOperations.Lose,1);
                    Debug.Log("Health: " + HealthSignals.Instance.OnGetHealth.Invoke());
                    if (HealthSignals.Instance.OnGetHealth.Invoke() <= 0)
                    {
                        UISignals.Instance.OnMenuUIManagement.Invoke(UIStates.ExtraHealth);
                        CoreGameSignals.Instance.OnPausingGame.Invoke();
                    }
                    else
                    {
                        CoreGameSignals.Instance.OnResettingBall?.Invoke();
                    }
                }
                
                
            }
        }

        private static void WaitForNextLevelMenu()
        {
            CoreGameSignals.Instance.OnSetIsBasket.Invoke(true);
            CoreGameSignals.Instance.OnBasket?.Invoke();
        }
    }
}
