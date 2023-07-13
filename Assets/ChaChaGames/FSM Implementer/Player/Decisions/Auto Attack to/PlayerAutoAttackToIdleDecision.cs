using ChaChaGames.Controllers;
using ChaChaGames.FSMBuilder;
using UnityEngine;

namespace ChaChaGames.FSMImplement
{
    [CreateAssetMenu(menuName = "Finite State Machine/Player/Decision/Auto Attack/to Idle", fileName = "new Auto Attack to Idle Decision")]
    public class PlayerAutoAttackToIdleDecision : Decision
    {
        #region PROPERTIES
        
        // public BoolRef isEnemyDetectedForAutoAttack;
        
        #endregion
                
        #region EVENT FUNCTIONS
        
        #endregion
                
        #region IMPLEMENTED FUNCTIONS
        
        public override bool Decide(StateController controller)
        {
            return false;
        }             
         
        #endregion  
        
        #region PUBLIC FUNCTIONS
        
        #endregion  
                
        #region PRIVATE FUNCTIONS
        
        #endregion
    }
}