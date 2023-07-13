using Sirenix.OdinInspector;
using UnityEngine;

namespace ChaChaGames.Scripts.RefValue
{
    [CreateAssetMenu(fileName = "Int Value", menuName = "ChaCha/Values/Int", order = 0)]
    public class IntRef : RefValue
    {
        private int _intValue;

        [ShowInInspector]
        public int Value
        {
            get => _intValue;
            set
            {
                _intValue = value;
                if (enableEvent) OnValueChanged();
            } 
        }
    }
}