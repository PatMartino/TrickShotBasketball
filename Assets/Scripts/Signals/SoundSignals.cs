using Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class SoundSignals : MonoSingleton<SoundSignals>
    {
        public UnityAction OnPlayBounceSound = delegate {  };
        public UnityAction OnPlaySwishSound = delegate {  };
    }
}
