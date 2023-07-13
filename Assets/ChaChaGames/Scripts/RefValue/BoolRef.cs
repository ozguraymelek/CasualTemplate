using Sirenix.OdinInspector;
using UnityEngine;

namespace ChaChaGames.Scripts.RefValue
{
    [CreateAssetMenu(fileName = "BoolRef", menuName = "ChaCha/Values/Bool", order = 0)]
    public class BoolRef : RefValue
    {
        private bool _boolValue;

        [ShowInInspector]
        public bool Value
        {
            get => _boolValue;
            set
            {
                _boolValue = value;
                if (enableEvent) OnValueChanged();
            }
        }
    }
}