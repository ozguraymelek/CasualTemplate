using Sirenix.OdinInspector;
using UnityEngine;

namespace ChaChaGames.Scripts.RefValue
{
    public class ValueSetter : MonoBehaviour
    {
//-------Public Variables-------//


//------Serialized Fields-------//
        [SerializeField] private SetTime SetTime;
        [SerializeField, Required] private RefValue Reference;

        [SerializeField, ShowIf("@Reference is FloatRef"), LabelText("Value"), Indent]
        private float FloatValue;

        [SerializeField, ShowIf("@Reference is BoolRef"), LabelText("Value"), Indent]
        private bool BoolValue;

//------Private Variables-------//


        #region UNITY_METHODS

        private void Awake()
        {
            if (SetTime != SetTime.Awake)
                SetValue();
        }

        private void Start()
        {
            if(SetTime == SetTime.Start)
                SetValue();
        }

        private void OnEnable()
        {
            if(SetTime == SetTime.OnEnable)
                SetValue();
        }

        #endregion


        #region PUBLIC_METHODS

        #endregion


        #region PRIVATE_METHODS

        private void SetValue()
        {
            switch (Reference)
            {
                case FloatRef floatRef:
                    floatRef.Value = FloatValue;
                    break;
                case BoolRef boolRef:
                    boolRef.Value = BoolValue;
                    break;
            }
        }
        #endregion
    }

    public enum SetTime
    {
        Awake,
        Start,
        OnEnable
    }
}