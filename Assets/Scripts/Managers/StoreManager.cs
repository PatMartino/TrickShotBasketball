using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using UnityEngine;
using UnityEngine.UI;
using Signals;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Managers
{
    public class StoreManager : MonoBehaviour
    {
        #region Serialized Field

        [SerializeField] private List<Transform> rareBallButtons = new List<Transform>();
        [SerializeField] private List<Transform> commonBallButtons = new List<Transform>();
        [SerializeField] private List<Transform> legendaryBallButtons = new List<Transform>();

        #endregion

        #region Private Field

        private bool _isInitialized;
        private bool[] _rareBalls = new bool[9];
        private bool[] _commonBalls = new bool[9];
        private bool[] _legendaryBalls = new bool[9];
        private byte _rareCount =0;
        private byte _commonCount =0;
        private byte _legendaryCount =0;
        

        #endregion

        #region OnEnable, Start, OnDisable

        private void OnEnable()
        {
            Init();
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion

        #region Private Functions
        
        private void Init()
        {
            if (!ES3.KeyExists("RareBallList"))
            {
                for (int i = 0; i < _rareBalls.Length; i++)
                {
                    //rareBallsList.Add(_rareBalls[i]);
                }
            }
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.OnBuyingBall += OnBuyingBall;
            UISignals.Instance.OnClickBallButton += OnClickBallButton;
        }

        private void OnBuyingBall(BallLevelTypes type)
        {
            switch (type)
            {
                case BallLevelTypes.Rare:
                    if (_rareCount < 9)
                    {
                        var random = Random.Range(0, 9);
                        while (true)
                        {
                            if (_rareBalls[random])
                            {
                                random = Random.Range(0, 9);
                            }
                            else
                            {
                                break;
                            }
                        }
                        Debug.Log(random);
                        _rareBalls[random] = true;
                        HaveBall();
                        _rareCount++;
                        
                    }
                    break;
                case BallLevelTypes.Legendary:
                    if (_legendaryCount < 9)
                    {
                        var random = Random.Range(0, 9);
                        while (true)
                        {
                            if (_legendaryBalls[random])
                            {
                                random = Random.Range(0, 9);
                            }
                            else
                            {
                                break;
                            }
                        }
                        Debug.Log(random);
                        _legendaryBalls[random] = true;
                        HaveBall();
                        _legendaryCount++;
                    }
                    break;
                case BallLevelTypes.Common:
                    if (_commonCount < 9)
                    {
                        var random = Random.Range(0, 9);
                        while (true)
                        {
                            if (_commonBalls[random])
                            {
                                random = Random.Range(0, 9);
                            }
                            else
                            {
                                break;
                            }
                        }
                        Debug.Log(random);
                        _commonBalls[random] = true;
                        HaveBall();
                        _commonCount++;
                    }
                    break;
            }
        }

        private void HaveBall()
        {
            for (int i = 0; i < _rareBalls.Length; i++)
            {
                if (_rareBalls[i])
                {
                    rareBallButtons[i].GetComponent<Button>().interactable = true;
                    rareBallButtons[i].GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f);
                }
                if (_commonBalls[i])
                {
                    commonBallButtons[i].GetComponent<Button>().interactable = true;
                    commonBallButtons[i].GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f);
                }
                if (_legendaryBalls[i])
                {
                    legendaryBallButtons[i].GetComponent<Button>().interactable = true;
                    legendaryBallButtons[i].GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f);
                }
            }
        }

        private void OnClickBallButton(int num, BallLevelTypes type)
        {
            var whiteColor = new Color(1f, 1f, 1f);
            var greenColor = new Color(0f, 1f, 0f);
            for (int i = 0; i < rareBallButtons.Count; i++)
            {
                rareBallButtons[i].GetComponent<Image>().color = whiteColor;
                legendaryBallButtons[i].GetComponent<Image>().color = whiteColor;
                commonBallButtons[i].GetComponent<Image>().color = whiteColor;
                
            }

            switch (type)
            {
                case BallLevelTypes.Common:
                    commonBallButtons[num].GetComponent<Image>().color = greenColor;
                    break;
                case BallLevelTypes.Rare:
                    rareBallButtons[num].GetComponent<Image>().color = greenColor;
                    break;
                case BallLevelTypes.Legendary:
                    legendaryBallButtons[num].GetComponent<Image>().color = greenColor;
                    break;
            }
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.OnBuyingBall -= OnBuyingBall;
            UISignals.Instance.OnClickBallButton -= OnClickBallButton;
        }

        #endregion
    }
}
