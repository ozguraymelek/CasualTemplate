using ChaChaGames.Controllers;
using UnityEngine;

namespace ChaChaGames.FSMBuilder
{
    [CreateAssetMenu(menuName = "Finite State Machine/Player/Action/Auto Attack", fileName = "new Auto Attack Data")]
    public class PlayerAutoAttack : Action
    {
        #region PROPERTIES
        
        #endregion
                
        #region EVENT FUNCTIONS
        
        #endregion
                
        #region IMPLEMENTED FUNCTIONS
        
        public override void Onset(StateController controller)
        {
            
        }

        public override void Updating(StateController controller)
        {
            
        }        
         
        #endregion  
        
        #region PUBLIC FUNCTIONS
        
        #endregion  
                
        #region PRIVATE FUNCTIONS
        
        private void LookAt(StateController controller)
        {
            
        }
        
        private void Move(StateController controller)
        {
            
        }
        
        private void Rotate(StateController controller)
        {
             
        }
        
        private void SetStepAnimation(StateController controller)
        {
            
        }
        
        private void Detector(StateController controller)
        {
            
        }
        
        #endregion
    }
}