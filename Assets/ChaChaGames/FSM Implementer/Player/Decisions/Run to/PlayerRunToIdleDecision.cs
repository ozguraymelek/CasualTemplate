using ChaChaGames.Controllers;
using ChaChaGames.FSMBuilder;
using ChaChaGames.Input;
using UnityEngine;

namespace ChaChaGames.FSMImplement
{
    [CreateAssetMenu(menuName = "Finite State Machine/Player/Decision/Run/to Idle", fileName = "new Run to Idle Data")]
    public class PlayerRunToIdleDecision : Decision
    {
        #region IMPLEMENTED FUNCTIONS
        
        public override bool Decide(StateController controller)
        {
            var magnitudeOfMovementVector = InputController.Magnitude?.Invoke();
            var decide = magnitudeOfMovementVector is 0f;
                
            return decide;
        }             
         
        #endregion  
    }
}