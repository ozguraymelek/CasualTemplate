using ChaChaGames.Controllers;
using UnityEngine;
using Sirenix.OdinInspector;

namespace ChaChaGames.FSMBuilder
{
    public class BaseState : SerializedScriptableObject
    {
        #region PUBLIC FUNCTIONS
        
        public virtual void Onset(StateController controller){} //event func. Start()
        public virtual void Updating(StateController controller){} //event func. Update()
        
        #endregion
    }
}