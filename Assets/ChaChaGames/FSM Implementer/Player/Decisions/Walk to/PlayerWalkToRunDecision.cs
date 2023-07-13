using ChaChaGames.Controllers;
using ChaChaGames.FSMBuilder;
using ChaChaGames.Input;
using UnityEngine;

namespace ChaChaGames.FSMImplement
{
    [CreateAssetMenu(menuName = "Finite State Machine/Player/Decision/Walk/to Run", fileName = "new Walk to Run Data")]
    public class PlayerWalkToRunDecision : Decision
    {
        #region PROPERTIES
         
        #endregion
                
        #region EVENT FUNCTIONS
        
        #endregion
                
        #region IMPLEMENTED FUNCTIONS
        
        public override bool Decide(StateController controller)
        {
            var magnitudeOfMovementVector = InputController.Magnitude?.Invoke();
            var decide = magnitudeOfMovementVector is > .71f and <= 1f;
            
            return decide;
        }             
         
        #endregion  
        
        #region PUBLIC FUNCTIONS
        
        #endregion  
                
        #region PRIVATE FUNCTIONS
        
        #endregion
    }
}