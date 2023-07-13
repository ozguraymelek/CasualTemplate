using Sirenix.OdinInspector;
using UnityEngine;

namespace ChaChaGames.Scripts.RefValue
{
    [CreateAssetMenu(fileName = "Vector3 Value", menuName = "ChaCha/Values/Vector3", order = 0)]
    public class Vector3Ref : RefValue
    {
        private Vector3 _vector3Value;

        [ShowInInspector]
        public Vector3 Value
        {
            get => _vector3Value;
            set
            {
                _vector3Value = value;
                if (enableEvent) OnValueChanged();
            }
        }
    }
}