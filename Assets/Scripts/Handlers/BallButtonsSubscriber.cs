using System;
using Signals;
using UnityEngine;
using Enums;
using UnityEngine.UI;

namespace Handlers
{
    public class BallButtonsSubscriber : MonoBehaviour
    {
        #region Serialized Field

        [SerializeField] private BallTypes type;

        #endregion

        #region Private Field

        private Button _button;
        private bool _isInitialized = false;

        #endregion

        #region OnEnable, Start, OnDisable

        private void OnEnable()
        {
            _button = GetComponent<Button>();
            if (!_isInitialized)
            {
                SubscribeEvents();
                _isInitialized = true;
            }
        }

        #endregion

        #region Private Functions

        private void SubscribeEvents()
        {
            switch (type)
            {
                case BallTypes.C1:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Common, 1));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(0,BallLevelTypes.Common));
                    break;
                case BallTypes.C2:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Common, 2));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(1,BallLevelTypes.Common));
                    break;
                case BallTypes.C3:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Common, 3));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(2,BallLevelTypes.Common));
                    break;
                case BallTypes.C4:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Common, 4));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(3,BallLevelTypes.Common));
                    break;
                case BallTypes.C5:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Common, 5));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(4,BallLevelTypes.Common));
                    break;
                case BallTypes.C6:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Common, 6));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(5,BallLevelTypes.Common));
                    break;
                case BallTypes.C7:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Common, 7));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(6,BallLevelTypes.Common));
                    break;
                case BallTypes.C8:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Common, 8));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(7,BallLevelTypes.Common));
                    break;
                case BallTypes.C9:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Common, 9));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(8,BallLevelTypes.Common));
                    break;
                case BallTypes.C10:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Common, 10));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(9,BallLevelTypes.Common));
                    break;
                case BallTypes.R1:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Rare, 1));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(0,BallLevelTypes.Rare));
                    break;
                case BallTypes.R2:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Rare, 2));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(1,BallLevelTypes.Rare));
                    break;
                case BallTypes.R3:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Rare, 3));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(2,BallLevelTypes.Rare));
                    break;
                case BallTypes.R4:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Rare, 4));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(3,BallLevelTypes.Rare));
                    break;
                case BallTypes.R5:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Rare, 5));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(4,BallLevelTypes.Rare));
                    break;
                case BallTypes.R6:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Rare, 6));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(5,BallLevelTypes.Rare));
                    break;
                case BallTypes.R7:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Rare, 7));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(6,BallLevelTypes.Rare));
                    break;
                case BallTypes.R8:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Rare, 8));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(7,BallLevelTypes.Rare));
                    break;
                case BallTypes.R9:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Rare, 9));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(8,BallLevelTypes.Rare));
                    break;
                case BallTypes.R10:
                    break;
                case BallTypes.L1:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Legendary, 1));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(0,BallLevelTypes.Legendary));
                    break;
                case BallTypes.L2:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Legendary, 2));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(1,BallLevelTypes.Legendary));
                    break;
                case BallTypes.L3:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Legendary, 3));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(2,BallLevelTypes.Legendary));
                    break;
                case BallTypes.L4:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Legendary, 4));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(3,BallLevelTypes.Legendary));
                    break;
                case BallTypes.L5:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Legendary, 5));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(4,BallLevelTypes.Legendary));
                    break;
                case BallTypes.L6:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Legendary, 6));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(5,BallLevelTypes.Legendary));
                    break;
                case BallTypes.L7:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Legendary, 7));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(6,BallLevelTypes.Legendary));
                    break;
                case BallTypes.L8:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Legendary, 8));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(7,BallLevelTypes.Legendary));
                    break;
                case BallTypes.L9:
                    _button.onClick.AddListener(() =>CoreGameSignals.Instance.OnSelectBall.Invoke(BallLevelTypes.Legendary, 9));
                    _button.onClick.AddListener(() =>UISignals.Instance.OnClickBallButton.Invoke(8,BallLevelTypes.Legendary));
                    break;
                case BallTypes.L10:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        #endregion
    }
}
