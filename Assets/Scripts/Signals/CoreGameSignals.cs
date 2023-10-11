using System;
using Extensions;
using UnityEngine;
using UnityEngine.Events;
using Enums;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction OnClearActiveLevel = delegate {  };
        public UnityAction<ushort> OnLevelInitialize = delegate {  }; 
        public UnityAction<Vector3,Rigidbody,Vector3> OnUpdateTrajectory= delegate {  };
        public UnityAction OnHidingLine =delegate {  };
        public UnityAction OnNextLevel = delegate {  };
        public UnityAction<GameStates> OnChangeGameState= delegate {  };
        public UnityAction OnPausingGame = delegate {  };
        public UnityAction OnResumingGame = delegate {  };
        public Func<GameStates> OnGettingGameState = () => GameStates.Game;
        public UnityAction OnTryAgain = delegate {  };
        public Func<ushort> OnGettingLevelID = () => 0;
        public Func<ushort> OnGettingBounceLeft = () => 0;
        public Func<ushort> OnGettingBounceData = () => 0;
        public UnityAction OnResettingBall = delegate {  };
        public UnityAction OnPlay = delegate {  };
        public UnityAction OnBasket = delegate {  };
        public UnityAction<BallLevelTypes> OnBuyingBall = delegate {  };
        public UnityAction<BallLevelTypes, int> OnSelectBall = delegate { };
        public Func<GameObject> OnGettingBall = () => null;
        public Func<Transform> OnGettingBallHolder = () => null;
        public UnityAction OnSetNetClothCollider = delegate {  };
        public UnityAction OnReturnCheckPoint = delegate {  };
        public UnityAction OnContinueWithExtraHealth = delegate {  };
        public Func<bool> OnGetIsBasket = () => false;
        public UnityAction<bool> OnSetIsBasket = delegate {  };
        public Func<bool> OnGetGamePass = () => false;
        public UnityAction OnGamePassActivated = delegate {  };
        public UnityAction OnGamePassDeactivated = delegate {  };
    }
}
