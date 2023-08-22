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
                Debug.Log("Bum");
                WaitForNextLevelMenu();
            }
            else
            {
                CoreGameSignals.Instance.OnResettingBall?.Invoke();
            }
        }

        private static async void WaitForNextLevelMenu()
        {
            await Task.Delay(500);
            CoreGameSignals.Instance.OnBasket?.Invoke();
        }
    }
}
