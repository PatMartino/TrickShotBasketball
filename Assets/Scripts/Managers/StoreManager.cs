using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.UI;
using Signals;
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
        private bool _isSaved;
        

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

        private void Update()
        {
            if (Input.GetKey(KeyCode.R))
            {
                Resetting();
            }
        }

        #endregion

        #region Private Functions
        
        private void Init()
        {
            if (ES3.KeyExists("isSaved"))
            {
                Load();
            }

            _commonBalls[0] = true;
            commonBallButtons[0].GetComponent<Button>().interactable = true;
        }

        private void OnSavingBallStore()
        {
            for (int i = 0; i < rareBallButtons.Count; i++)
            {
                
                //ES3.Save($"legendaryBallButtons{i}interactable", legendaryBallButtons[i].GetComponent<Button>().interactable);
                ES3.Save($"rareBallButtons{i}ButtonColor", rareBallButtons[i].GetComponent<Image>().color);
                ES3.Save($"commonBallButtons{i}ButtonColor", commonBallButtons[i].GetComponent<Image>().color);
                ES3.Save($"legendaryBallButtons{i}ButtonColor", legendaryBallButtons[i].GetComponent<Image>().color);
                
                //ES3.Save($"rareBallButtons{i}ImageColor", rareBallButtons[i].GetChild(0).GetComponent<Image>().color);
                //ES3.Save($"commonBallButtons{i}ImageColor", commonBallButtons[i].GetChild(0).GetComponent<Image>().color);
                //ES3.Save($"legendaryBallButtons{i}ImageColor", legendaryBallButtons[i].GetChild(0).GetComponent<Image>().color);
                
                //ES3.Save($"rareBalls{i}", _rareBalls[i]);
                //ES3.Save($"commonBalls{i}", _commonBalls[i]);
                //ES3.Save($"legendaryBalls{i}", _legendaryBalls[i]);
            }
            //ES3.Save("rareCount", _rareCount);
            //ES3.Save("commonCount", _commonCount);
            //ES3.Save("legendaryCount", _legendaryCount);
            
            
            Debug.LogWarning("Saved!");
        }
        

        private void Load()
        {
            for (int i = 0; i < rareBallButtons.Count; i++)
            {
                if (ES3.KeyExists($"rareBallButtons{i}interactable"))
                {
                    rareBallButtons[i].GetComponent<Button>().interactable 
                        = ES3.Load<bool>($"rareBallButtons{i}interactable");
                }
                else
                {
                    rareBallButtons[i].GetComponent<Button>().interactable = false;
                }
                
                if (ES3.KeyExists($"commonBallButtons{i}interactable"))
                {
                    commonBallButtons[i].GetComponent<Button>().interactable 
                        = ES3.Load<bool>($"commonBallButtons{i}interactable");
                }
                else
                {
                    commonBallButtons[i].GetComponent<Button>().interactable = false;
                }
                if (ES3.KeyExists($"legendaryBallButtons{i}interactable"))
                {
                    legendaryBallButtons[i].GetComponent<Button>().interactable 
                        = ES3.Load<bool>($"legendaryBallButtons{i}interactable");
                }
                else
                {
                    legendaryBallButtons[i].GetComponent<Button>().interactable = false;
                }
                
                
                if (ES3.KeyExists($"rareBallButtons{i}ButtonColor"))
                {
                    rareBallButtons[i].GetComponent<Image>().color 
                        = ES3.Load<Color>($"rareBallButtons{i}ButtonColor");
                }
                
                if (ES3.KeyExists($"commonBallButtons{i}ButtonColor"))
                {
                    commonBallButtons[i].GetComponent<Image>().color 
                        = ES3.Load<Color>($"commonBallButtons{i}ButtonColor");
                }
                
                if (ES3.KeyExists($"legendaryBallButtons{i}ButtonColor"))
                {
                    legendaryBallButtons[i].GetComponent<Image>().color
                        = ES3.Load<Color>($"legendaryBallButtons{i}ButtonColor");
                }
                
                
                
                if (ES3.KeyExists($"rareBallButtons{i}ImageColor"))
                {
                    rareBallButtons[i].GetChild(0).GetComponent<Image>().color 
                        = ES3.Load<Color>($"rareBallButtons{i}ImageColor");
                }
                
                if (ES3.KeyExists($"commonBallButtons{i}ImageColor"))
                {
                    commonBallButtons[i].GetChild(0).GetComponent<Image>().color 
                        = ES3.Load<Color>($"commonBallButtons{i}ImageColor");
                }
                
                if (ES3.KeyExists($"legendaryBallButtons{i}ImageColor"))
                {
                    legendaryBallButtons[i].GetChild(0).GetComponent<Image>().color
                        = ES3.Load<Color>($"legendaryBallButtons{i}ImageColor");
                }
                
                
                if (ES3.KeyExists($"rareBalls{i}"))
                {
                    _rareBalls[i]=ES3.Load<bool>($"rareBalls{i}");
                }
                
                if (ES3.KeyExists($"commonBalls{i}"))
                {
                    _commonBalls[i]= ES3.Load<bool>($"commonBalls{i}");
                }
                
                if (ES3.KeyExists($"legendaryBalls{i}"))
                {
                    _legendaryBalls[i]=ES3.Load<bool>($"legendaryBalls{i}");
                }
                
            }
            if (ES3.KeyExists("rareCount"))
            {
                _rareCount = ES3.Load<byte>("rareCount");;
            }
            if (ES3.KeyExists("commonCount"))
            {
                _commonCount = ES3.Load<byte>("commonCount");
            }
            if (ES3.KeyExists("legendaryCount"))
            {
                _legendaryCount = ES3.Load<byte>("legendaryCount");
            }
            
            Debug.LogWarning("Load!");
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.OnBuyingBall += OnBuyingBall;
            UISignals.Instance.OnClickBallButton += OnClickBallButton;
            SaveSignals.Instance.OnSavingBallStore += OnSavingBallStore;
        }

        private void OnBuyingBall(BallLevelTypes type)
        {
            switch (type)
            {
                case BallLevelTypes.Rare:
                    if(CoinSignals.Instance.OnGetCoin.Invoke()<500)
                        return;
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
                        _rareCount++;
                        ES3.Save($"rareBalls{random}", _rareBalls[random]);
                        ES3.Save("rareCount", _rareCount);
                        _isSaved = true;
                        ES3.Save("isSaved",_isSaved);
                        CoinSignals.Instance.OnSetCoin?.Invoke(CoinOperations.Lose,500);
                        HaveBall();
                        
                    }
                    break;
                case BallLevelTypes.Legendary:
                    if(CoinSignals.Instance.OnGetCoin.Invoke()<750)
                        return;
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
                        _legendaryCount++;
                        ES3.Save($"legendaryBalls{random}", _legendaryBalls[random]);
                        ES3.Save("legendaryCount", _legendaryCount);
                        _isSaved = true;
                        ES3.Save("isSaved",_isSaved);
                        CoinSignals.Instance.OnSetCoin?.Invoke(CoinOperations.Lose,750);
                        HaveBall();
                    }
                    break;
                case BallLevelTypes.Common:
                    if(CoinSignals.Instance.OnGetCoin.Invoke()<250)
                        return;
                    if (_commonCount < 8)
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
                        _commonCount++;
                        ES3.Save($"commonBalls{random}", _commonBalls[random]);
                        ES3.Save("commonCount", _commonCount);
                        _isSaved = true;
                        ES3.Save("isSaved",_isSaved);
                        CoinSignals.Instance.OnSetCoin?.Invoke(CoinOperations.Lose,250);
                        HaveBall();
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
                    ES3.Save($"rareBallButtons{i}interactable", rareBallButtons[i].GetComponent<Button>().interactable);
                    ES3.Save($"rareBallButtons{i}ImageColor", rareBallButtons[i].GetChild(0).GetComponent<Image>().color);
                }
                if (_commonBalls[i])
                {
                    commonBallButtons[i].GetComponent<Button>().interactable = true;
                    commonBallButtons[i].GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f);
                    ES3.Save($"commonBallButtons{i}interactable", commonBallButtons[i].GetComponent<Button>().interactable);
                    ES3.Save($"commonBallButtons{i}ImageColor", commonBallButtons[i].GetChild(0).GetComponent<Image>().color);
                }
                if (_legendaryBalls[i])
                {
                    legendaryBallButtons[i].GetComponent<Button>().interactable = true;
                    legendaryBallButtons[i].GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f);
                    ES3.Save($"legendaryBallButtons{i}interactable", legendaryBallButtons[i].GetComponent<Button>().interactable);
                    ES3.Save($"legendaryBallButtons{i}ImageColor", legendaryBallButtons[i].GetChild(0).GetComponent<Image>().color);
                }
            }
        }

        private void OnClickBallButton(int num, BallLevelTypes type)
        {
            var whiteColor = new Color(0f, 0.8039216f, 0.8313726f);
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

            if (Time.timeScale != 0)
            {
                CoreGameSignals.Instance.OnClearActiveLevel?.Invoke();
                CoreGameSignals.Instance.OnLevelInitialize?.Invoke(CoreGameSignals.Instance.OnGettingLevelID.Invoke());
            }
        }

        private void Resetting()
        {
            for (int i = 0; i < rareBallButtons.Count; i++)
            {
                ES3.DeleteKey($"rareBallButtons{i}ButtonColor");
                ES3.DeleteKey($"commonBallButtons{i}ButtonColor");
                ES3.DeleteKey($"legendaryBallButtons{i}ButtonColor");
                
                ES3.DeleteKey($"rareBallButtons{i}ImageColor");
                ES3.DeleteKey($"commonBallButtons{i}ImageColor");
                ES3.DeleteKey($"legendaryBallButtons{i}ImageColor");
                
                ES3.DeleteKey($"rareBalls{i}");
                ES3.DeleteKey($"commonBalls{i}");
                ES3.DeleteKey($"legendaryBalls{i}");
                
                ES3.DeleteKey($"rareBallButtons{i}interactable");
                ES3.DeleteKey($"commonBallButtons{i}interactable");
                ES3.DeleteKey($"legendaryBallButtons{i}interactable");
            }
            ES3.DeleteKey("rareCount");
            ES3.DeleteKey("commonCount");
            ES3.DeleteKey("legendaryCount");
            ES3.DeleteKey("isSaved");
            Debug.LogWarning("Reset!");
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.OnBuyingBall -= OnBuyingBall;
            UISignals.Instance.OnClickBallButton -= OnClickBallButton;
            SaveSignals.Instance.OnSavingBallStore -= OnSavingBallStore;
        }

        #endregion
    }
}
