using Interfaces;
using UnityEngine;

namespace Commands.Level
{
    public class OnLevelLoaderCommand : ICommand
    {
        private readonly Transform _levelHolder;
        private readonly Transform _ballHolder;

        public OnLevelLoaderCommand(Transform levelHolder, Transform ballHolder)
        {
            _levelHolder = levelHolder;
            _ballHolder = ballHolder;
        }

        public void Execute()
        {
        }

        public void Execute(ushort levelID)
        {
            Object.Instantiate(Resources.Load<GameObject>($"Prefabs/LevelPrefabs/level{levelID}"), _levelHolder);
            Object.Instantiate(Resources.Load<GameObject>("Prefabs/BallPrefabs/Ball1"), _ballHolder);
        }
    }
}
