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
            UISignals.Instance.OnMenuUIManagement?.Invoke(UIStates.MainMenuUI);
            CoreGameSignals.Instance.OnSetNetClothCollider?.Invoke();
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
        }

        private void OnPlay()
        {
            Debug.Log("Bum");
            CoreGameSignals.Instance.OnChangeGameState?.Invoke(GameStates.Game);
            UISignals.Instance.OnMenuUIManagement?.Invoke(UIStates.InGameUI);
            AdSignals.Instance.OnLoadBanner?.Invoke();
            AdSignals.Instance.OnShowingBanner?.Invoke();
        }
        
        private void OnNextLevel()
        {
            CoreGameSignals.Instance.OnClearActiveLevel?.Invoke();
            AdSignals.Instance.OnLoadingAd?.Invoke();
            AdSignals.Instance.OnShowingAd?.Invoke();
            levelID++;
            //CoreGameSignals.Instance.OnClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.OnLevelInitialize?.Invoke(levelID);
            
            CoreGameSignals.Instance.OnChangeGameState?.Invoke(GameStates.Game);
            UISignals.Instance.OnMenuUIManagement?.Invoke(UIStates.InGameUI);
            //CoreGameSignals.Instance.OnSetNetClothCollider?.Invoke();
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
            CoinSignals.Instance.OnSetCoin?.Invoke(CoinOperations.Gain,25);
            UISignals.Instance.OnMenuUIManagement?.Invoke(UIStates.NextLevelUI);
            CoreGameSignals.Instance.OnPausingGame?.Invoke();
            
        }

        private ushort OnGettingLevelID()
        {
            return levelID;
        }

        private void LoadLevel()
        {
            if (!ES3.KeyExists("levelID")) return;
            levelID= ES3.Load<ushort>("levelID");
            Debug.Log("Game Load! "+ ES3.Load("levelID"));
        }

        private Transform OnGettingBallHolder()
        {
            return ballHolder;
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
        }

        #endregion
        
    }
}
