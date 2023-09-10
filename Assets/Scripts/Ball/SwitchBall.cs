using System;
using Signals;
using Enums;
using UnityEngine;

namespace Ball
{
    public class SwitchBall : MonoBehaviour
    {
        #region Serialized Field

        

        #endregion
        
        #region Private Field

        private GameObject _ball;
        private string _resources;

        #endregion

        #region OnEnable, Start, OnDisable, Awake

        private void OnEnable()
        {
            Init();
            SubscribeEvents();
        }

        private void Awake()
        {
            
        }

        #endregion

        #region Private Functions

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.OnSelectBall += OnSelectBall;
            CoreGameSignals.Instance.OnGettingBall += OnGettingBall;
        }

        private void Init()
        {
            if (ES3.KeyExists("Ball"))
            {
                Debug.Log("Top Var");
                _ball = Resources.Load<GameObject>(ES3.Load<string>("reso"));
            }
            else
            {
                Debug.Log("Top Yok");
                _ball = Resources.Load<GameObject>($"Prefabs/BallPrefabs/Common/1");
            }
        }

        private void OnSelectBall(BallLevelTypes type, int num)
        {
            switch (type)
            {
                case BallLevelTypes.Common:
                    _ball =Resources.Load<GameObject>($"Prefabs/BallPrefabs/Common/{num}");
                    _resources = $"Prefabs/BallPrefabs/Common/{num}";
                    break;
                case BallLevelTypes.Rare:
                    _ball =Resources.Load<GameObject>($"Prefabs/BallPrefabs/Rare/{num}");
                    _resources = $"Prefabs/BallPrefabs/Rare/{num}";
                    break;
                case BallLevelTypes.Legendary:
                    _ball =Resources.Load<GameObject>($"Prefabs/BallPrefabs/Legendary/{num}");
                    _resources = $"Prefabs/BallPrefabs/Legendary/{num}";
                    break;
                
            }
            ES3.Save("Ball",_ball);
            ES3.Save("reso", _resources);
        }

        private GameObject OnGettingBall()
        {
            return _ball;
        }


        #endregion
    }
}
