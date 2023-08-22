using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "BounceData", menuName = "Bounce Data")]
    public class BounceData : ScriptableObject
    {
        [SerializeField] private ushort maxBounce;

        public ushort MaxBounce => maxBounce;

    }
}
