using Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class SoundSignals : MonoSingleton<SoundSignals>
    {
        public UnityAction OnPlayBounceSound = delegate {  };
        public UnityAction OnPlaySwishSound = delegate {  };
        public UnityAction OnMuteMusic = delegate {  };
        public UnityAction OnMuteSoundEffects = delegate {  };
    }
}
