using ChaChaGames.Controllers;
using ChaChaGames.FSMBuilder;
using ChaChaGames.Input;
using UnityEngine;

namespace ChaChaGames.FSMImplement
{
    [CreateAssetMenu(menuName = "Finite State Machine/Player/Decision/Idle/to Walk", fileName = "new Idle to Walk Data")]
    public class PlayerIdleToWalkDecision : Decision
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