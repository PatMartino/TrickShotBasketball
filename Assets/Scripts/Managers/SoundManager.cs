using System;
using UnityEngine;
using Signals;

namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private AudioSource bounceSound;
        [SerializeField] private AudioSource swishSound;
        [SerializeField] private AudioSource music;
        [SerializeField] private AudioSource backGround;

        #endregion

        #region OnEnable

        private void OnEnable()
        {
            SubscribeEvents();
        }

        #endregion

        #region Private Fields

        private void SubscribeEvents()
        {
            SoundSignals.Instance.OnPlayBounceSound += OnPlayBounceSound;
            SoundSignals.Instance.OnPlaySwishSound += OnPlaySwishSound;
            SoundSignals.Instance.OnMuteMusic += OnMuteMusic;
            SoundSignals.Instance.OnMuteSoundEffects += OnMuteSoundEffects;
        }

        private void OnPlayBounceSound()
        {
            bounceSound.Play();
        }
        
        private void OnPlaySwishSound()
        {
            swishSound.Play();
        }

        private void OnMuteMusic()
        {
            music.mute = !music.mute;
            backGround.mute = !backGround.mute;
            //UISignals.Instance.OnChangeMusicIcon?.Invoke();
        }

        private void OnMuteSoundEffects()
        {
            bounceSound.mute = !bounceSound.mute;
            swishSound.mute = !swishSound.mute;
            //UISignals.Instance.OnChangeSoundEffectIcon?.Invoke();
        }

        #endregion

        
    }
}
