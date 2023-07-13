using ChaChaGames.Controllers;
using ChaChaGames.FSMBuilder;
using ChaChaGames.Input;
using UnityEngine;

namespace ChaChaGames.FSMImplement
{
    [CreateAssetMenu(menuName = "Finite State Machine/Player/Decision/Run/to Walk", fileName = "new Run to Walk Data")]
    public class PlayerRunToWalkDecision : Decision
    {
        #region IMPLEMENTED FUNCTIONS
        
        public override bool Decide(StateController controller)
        {
            var magnitudeOfMovementVector = InputController.Magnitude?.Invoke();
            var decide = magnitudeOfMovementVector is < .71f and > 0f;
            
            return decide;
        }             
         
        #endregion  
    }
}