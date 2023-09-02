using Interfaces;
using UnityEngine;

namespace Commands.Level
{
    public class OnLevelDestroyerCommand : ICommand
    {
        private readonly Transform _levelHolder;
        private readonly Transform _ballHolder;

        public OnLevelDestroyerCommand(Transform levelHolder, Transform ballHolder)
        {
            _levelHolder = levelHolder;
            _ballHolder = ballHolder;
        }

        public void Execute()
        {
            Object.Destroy(_levelHolder.GetChild(0).gameObject);
            Object.Destroy(_ballHolder.GetChild(0).gameObject);
        }

        public void Execute(ushort value)
        {
        }
    }
}
