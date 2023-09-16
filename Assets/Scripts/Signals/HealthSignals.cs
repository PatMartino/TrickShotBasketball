using System;
using Enums;
using Extensions;
using UnityEngine.Events;

namespace Signals
{
    public class HealthSignals: MonoSingleton<HealthSignals>
    {
        
        public Func<int> OnGetHealth = () => 0;
        public UnityAction<CoinOperations, int> OnSetHealth = delegate {  }; 
        public Func<int> OnGetCheckPoint = () => 0;
        public UnityAction OnSetCheckPoint = delegate {  };
        public UnityAction OnCheckIsACheckpoint = delegate {  };
    }
}