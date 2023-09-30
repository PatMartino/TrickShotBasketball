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
        }

        private void OnPlayBounceSound()
        {
            bounceSound.Play();
        }
        
        private void OnPlaySwishSound()
        {
            swishSound.Play();
        }

        #endregion

        
    }
}
