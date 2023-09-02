using Extensions;
using UnityEngine.Events;
using Enums;

namespace Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityAction<UIStates> OnMenuUIManagement = delegate {  };
        public UnityAction OnSettingLevelText =delegate {  };
        public UnityAction OnSettingBounceText = delegate {  };
        public UnityAction<int, BallLevelTypes> OnClickBallButton = delegate {  };
    }
}