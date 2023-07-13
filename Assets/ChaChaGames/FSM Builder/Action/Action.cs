using ChaChaGames.Controllers;
using ChaChaGames.Scripts.RefValue;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ChaChaGames.FSMBuilder
{
    public abstract class Action : ScriptableObject
    {
        #region PROPERTIES
        
        [TabGroup("Input Variables"),GUIColor(0f,1f,0f,1f)]
        [ShowInInspector] protected FloatRef VerticalInput;
        [TabGroup("Input Variables"),GUIColor(0f,1f,0f,1f)]
        [ShowInInspector] protected FloatRef HorizontalInput;
        [TabGroup("Input Variables"),GUIColor(0f,1f,0f,1f)]
        [ShowInInspector] protected Vector3Ref MovementVector;
        
        #endregion
        
        #region PUBLIC FUNCTIONS
        
        public virtual void Onset(StateController controller){}
        public virtual void Updating(StateController controller){}
        
        #endregion 
    }
}