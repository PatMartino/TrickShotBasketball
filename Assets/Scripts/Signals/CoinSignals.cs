using System;
using Extensions;
using UnityEngine.Events;
using Enums;

namespace Signals
{
    public class CoinSignals:MonoSingleton<CoinSignals>
    {
        public UnityAction<CoinOperations,int> OnSetCoin = delegate {  };
        public Func<int> OnGetCoin = () => 0;
    }
}