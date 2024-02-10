using System.Threading.Tasks;
using Commands.Level;
using UnityEngine;
using Signals;
using Enums;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        #region Serialized Fields
        [SerializeField] private ushort levelID;
        [SerializeField] private Transform levelHolder;
        [SerializeField] private Transform ballHolder;
        #endregion

        #region Private Fields

        private OnLevelLoaderCommand _levelLoaderCommand;
        private OnLevelDestroyerCommand _levelDestroyerCommand;
        private bool _isBasket;

        #endregion

        #region Awake, OnEnable, Start, OnDisable
        private void Awake()
        {
            Init();
            
        }
        
        private void OnEnable()
        {
            SubscribeEvents();
            LoadLevel();
        }
        
        private void Start()
        {
            CoreGameSignals.Instance.OnLevelInitialize?.Invoke(levelID);
            CoreGameSignals.Instance.OnSetNetClothCollider?.Invoke();
            WaitForUI();
            
        }

        private async void WaitForUI()
        {
            await Task.Delay(500);
            UISignals.Instance.OnMenuUIManagement?.Invoke(UIStates.MainMenuUI);
        }
        
        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion

        #region Private Functions

        private void Init()
        {
            _levelLoaderCommand = new OnLevelLoaderCommand(levelHolder, ballHolder);
            _levelDestroyerCommand = new OnLevelDestroyerCommand(levelHolder, ballHolder);
        }
        
        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.OnLevelInitialize += _levelLoaderCommand.Execute;
            CoreGameSignals.Instance.OnClearActiveLevel += _levelDestroyerCommand.Execute;
            CoreGameSignals.Instance.OnNextLevel += OnNextLevel;
            CoreGameSignals.Instance.OnTryAgain += OnTryAgain;
            CoreGameSignals.Instance.OnGettingLevelID += OnGettingLevelID;
            CoreGameSignals.Instance.OnPlay += OnPlay;
            CoreGameSignals.Instance.OnBasket += OnBasket;
            CoreGameSignals.Instance.OnGettingBallHolder += OnGettingBallHolder;
            CoreGameSignals.Instance.OnReturnCheckPoint += OnReturnCheckPoint;
            CoreGameSignals.Instance.OnContinueWithExtraHealth += OnContinueWithExtraHealth;
            CoreGameSignals.Instance.OnGetIsBasket += OnGetIsBasket;
            CoreGameSignals.Instance.OnSetIsBasket += OnSetIsBasket;
        }

        private void OnPlay()
        {
            Debug.Log("Bum");
            CoreGameSignals.Instance.OnChangeGameState?.Invoke(GameStates.Game);
            UISignals.Instance.OnMenuUIManagement?.Invoke(UIStates.InGameUI);
            AdSignals.Instance.OnLoadBanner?.Invoke();
            AdSignals.Instance.OnShowingBanner?.Invoke();
            UISignals.Instance.OnMenuUIManagement?.Invoke(UIStates.HealthTutorial);
        }
        
        private void OnNextLevel()
        {
            CoreGameSignals.Instance.OnClearActiveLevel?.Invoke();
            //AdSignals.Instance.OnLoadInterstitialAds?.Invoke();
            AdSignals.Instance.OnShowInterstitialAds?.Invoke();
            CheckMaxLevel();
            HealthSignals.Instance.OnCheckIsACheckpoint?.Invoke();
            //CoreGameSignals.Instance.OnClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.OnLevelInitialize?.Invoke(levelID);
            
            CoreGameSignals.Instance.OnChangeGameState?.Invoke(GameStates.Game);
            UISignals.Instance.OnMenuUIManagement?.Invoke(UIStates.InGameUI);
            _isBasket = false;
            CoreGameSignals.Instance.OnResumingGame?.Invoke();
            AdSignals.Instance.OnLoadBanner?.Invoke();
            AdSignals.Instance.OnShowingBanner?.Invoke();
            ES3.Save<ushort>("levelID", levelID);
            Debug.Log("Game Saved! "+ ES3.Load("levelID"));
        }

        private void OnTryAgain()
        {
            CoreGameSignals.Instance.OnChangeGameState?.Invoke(GameStates.Game);
        }

        private void OnBasket()
        {
            CoinSignals.Instance.OnSetCoin?.Invoke(CoinOperations.Gain,100);
            UISignals.Instance.OnMenuUIManagement?.Invoke(UIStates.NextLevelUI);
            //CoreGameSignals.Instance.OnPausingGame?.Invoke();
            
        }

        private void OnReturnCheckPoint()
        {
            CoreGameSignals.Instance.OnClearActiveLevel?.Invoke();
            AdSignals.Instance.OnLoadInterstitialAds?.Invoke();
            AdSignals.Instance.OnShowInterstitialAds?.Invoke();
            levelID = (ushort)HealthSignals.Instance.OnGetCheckPoint.Invoke();
            CoreGameSignals.Instance.OnLevelInitialize?.Invoke(levelID);
            HealthSignals.Instance.OnSetHealth?.Invoke(CoinOperations.Gain,12);
            CoreGameSignals.Instance.OnChangeGameState?.Invoke(GameStates.Game);
            UISignals.Instance.OnMenuUIManagement?.Invoke(UIStates.InGameUI);
            CoreGameSignals.Instance.OnResumingGame?.Invoke();
            AdSignals.Instance.OnLoadBanner?.Invoke();
            AdSignals.Instance.OnShowingBanner?.Invoke();
            ES3.Save<ushort>("levelID", levelID);
            Debug.Log("Game Saved! "+ ES3.Load("levelID"));
        }

        private void OnContinueWithExtraHealth()
        {
            CoreGameSignals.Instance.OnResumingGame?.Invoke();
            UISignals.Instance.OnMenuUIManagement?.Invoke(UIStates.InGameUI);
            CoreGameSignals.Instance.OnResettingBall?.Invoke();
        }

        private void CheckMaxLevel()
        {
            if (levelID <= 100)
            {
                levelID++;
            }
            else
            {
                levelID = 1;
            }
        }

        private ushort OnGettingLevelID()
        {
            return levelID;
        }

        private void LoadLevel()
        {
            levelID = ES3.KeyExists("levelID") ? ES3.Load<ushort>("levelID") : (ushort)1;

            //Debug.Log("Game Load! "+ ES3.Load("levelID"));
        }

        private Transform OnGettingBallHolder()
        {
            return ballHolder;
        }

        private bool OnGetIsBasket()
        {
            return _isBasket;
        }

        private void OnSetIsBasket(bool value)
        {
            _isBasket = value;
        } 

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.OnLevelInitialize -= _levelLoaderCommand.Execute;
            CoreGameSignals.Instance.OnClearActiveLevel -= _levelDestroyerCommand.Execute;
            CoreGameSignals.Instance.OnNextLevel -= OnNextLevel;
            CoreGameSignals.Instance.OnTryAgain -= OnTryAgain;
            CoreGameSignals.Instance.OnGettingLevelID -= OnGettingLevelID;
            CoreGameSignals.Instance.OnPlay -= OnPlay;
            CoreGameSignals.Instance.OnBasket -= OnBasket;
            CoreGameSignals.Instance.OnGettingBallHolder -= OnGettingBallHolder;
            CoreGameSignals.Instance.OnReturnCheckPoint -= OnReturnCheckPoint;
            CoreGameSignals.Instance.OnContinueWithExtraHealth -= OnContinueWithExtraHealth;
            CoreGameSignals.Instance.OnGetIsBasket -= OnGetIsBasket;
            CoreGameSignals.Instance.OnSetIsBasket -= OnSetIsBasket;
        }

        #endregion
        
    }
}
