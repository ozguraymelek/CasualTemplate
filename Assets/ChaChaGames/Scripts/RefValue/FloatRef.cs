using Sirenix.OdinInspector;
using UnityEngine;

namespace ChaChaGames.Scripts.RefValue
{
    [CreateAssetMenu(fileName = "Float Value", menuName = "ChaCha/Values/Float", order = 0)]
    public class FloatRef : RefValue
    {
        private float _floatValue;

        [ShowInInspector]
        public float Value
        {
            get => _floatValue;
            set
            {
                _floatValue = value;
                if (enableEvent) OnValueChanged();
            }
        }
    }
}