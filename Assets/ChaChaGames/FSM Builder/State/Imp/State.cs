using System.Collections.Generic;
using ChaChaGames.Controllers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ChaChaGames.FSMBuilder
{
    [CreateAssetMenu(menuName = "Finite State Machine/Player/States/State", fileName = "new Player State")]
    public class State : BaseState
    {
        #region PROPERTIES
        
        [Title("All actions for this state")]
        public List<Action> Actions = new List<Action>();
        
        [Title("All transitions for this state")]
        public List<Transition> Transitions = new List<Transition>();
        
        #endregion
                
        #region IMPLEMENTED FUNCTIONS
        
        public override void Onset(StateController controller)
        {
            foreach (var action in Actions)
            {
                action.Onset(controller);
            }
        }
        
        public override void Updating(StateController controller)
        {
            foreach (var action in Actions)
            {
                action.Updating(controller);
            }
            
            foreach (var transition in Transitions)
            {
                transition.Execute(controller);
            }
        }
        
        #endregion  
        
        #region PUBLIC FUNCTIONS
        
        #endregion  
                
        #region PRIVATE FUNCTIONS
        
        #endregion
    }
}