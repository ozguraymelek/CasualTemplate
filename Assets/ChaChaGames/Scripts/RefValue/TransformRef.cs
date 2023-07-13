using Sirenix.OdinInspector;
using UnityEngine;

namespace ChaChaGames.Scripts.RefValue
{
    [CreateAssetMenu(fileName = "Transform Value", menuName = "ChaCha/Values/Transform", order = 0)]
    public class TransformRef : RefValue
    {
        private Transform _transformValue;

        [ShowInInspector]
        public Transform Value
        {
            get => _transformValue;
            set
            {
                _transformValue = value;
                if (enableEvent) OnValueChanged();
            }
        }
    }
}