using System;
using UnityEngine;
using Signals;
using TMPro;
using UnityEngine.UI;

namespace Controllers
{
    public class MainMenuPanelController : MonoBehaviour
    {
        #region Serialized Fields
        
        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI levelText;

        [Header("GameObjects")]
        [SerializeField] private GameObject musicIcon;
        [SerializeField] private GameObject soundIcon;

        [Header("Images")] 
        [SerializeField] private Sprite musicOn;
        [SerializeField] private Sprite musicOff;
        [SerializeField] private Sprite soundEffectsOn;
        [SerializeField] private Sprite  soundEffectsOff;
        
        #endregion

        #region Private Fields

        private bool _isMusicMuted;
        private bool _isSoundEffectsMuted;

        #endregion

        #region OnEnable

        private void OnEnable()
        {
            SettingLevelText();
            SubscribeEvents();
        }

        #endregion

        #region Private Functions

        private void SubscribeEvents()
        {
            UISignals.Instance.OnChangeMusicIcon += OnChangeMusicIcon;
            UISignals.Instance.OnChangeSoundEffectIcon += OnChangeSoundEffectIcon;
        }

        private void SettingLevelText()
        {
            int level = CoreGameSignals.Instance.OnGettingLevelID();
            levelText.text = "Level " + level;
            Debug.Log("Level: "+(int)CoreGameSignals.Instance.OnGettingLevelID());
        }

        private void OnChangeMusicIcon()
        {
            if (!_isMusicMuted)
            {
                musicIcon.GetComponent<Image>().sprite = musicOff;
                _isMusicMuted = true;
            }
            else
            {
                musicIcon.GetComponent<Image>().sprite = musicOn;
                _isMusicMuted = false;
            }
        }
        
        private void OnChangeSoundEffectIcon()
        {
            if (!_isSoundEffectsMuted)
            {
                soundIcon.GetComponent<Image>().sprite = soundEffectsOff;
                _isSoundEffectsMuted = true;
            }
            else
            {
                soundIcon.GetComponent<Image>().sprite = soundEffectsOn;
                _isSoundEffectsMuted = false;
            }
        }

        #endregion

    }
}
