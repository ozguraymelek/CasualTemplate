using ChaChaGames.Controllers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ChaChaGames.FSMBuilder
{
    [CreateAssetMenu(menuName = "Finite State Machine/Transition")]
    public sealed class Transition : SerializedScriptableObject
    {
        #region PROPERTIES
        
        [Title("Select decision for transition")]
        public Decision Decision;

        [Title("Select state for transition or stay")]
        public BaseState NewState;
        public BaseState StayState;
        
        #endregion
        
        #region PUBLIC FUNCTIONS
        
        public void Execute(StateController controller)
        {
            if (Decision.Decide(controller) && NewState is not RemainInState)
                controller.CurrentState = NewState;

            else if (Decision.Decide(controller) == false && StayState is not RemainInState)
                controller.CurrentState = StayState;
        }
        
        #endregion 
    }
}