using UnityEngine;
using System;
using GenericScriptableArchitecture;
using Sirenix.OdinInspector;

namespace ChaChaGames.Scripts.RefValue
{
    public class RefValue : ScriptableObject
    {
        public bool enableEvent;
        
        [ShowIf("enableEvent")][Indent(2)]
        public ScriptableEvent onValueChanged;

        public void OnValueChanged()
        {
            onValueChanged.Invoke();
        }
    }
}

