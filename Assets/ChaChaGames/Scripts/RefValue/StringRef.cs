using UnityEngine;

namespace ChaChaGames.Scripts.RefValue
{
    [CreateAssetMenu(fileName = "String Value", menuName = "ChaCha/Values/String", order = 0)]
    public class StringRef : RefValue
    {
        private string _stringValue;

        public string Value
        {
            get => _stringValue;
            set
            {
                _stringValue = value;
                if (enableEvent) OnValueChanged();
            }
        }
    }
}