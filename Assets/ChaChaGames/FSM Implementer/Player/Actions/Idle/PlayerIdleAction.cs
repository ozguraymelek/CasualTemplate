using ChaChaGames.Controllers;
using UnityEngine;

namespace ChaChaGames.FSMBuilder
{
    [CreateAssetMenu(menuName = "Finite State Machine/Player/Action/Idle", fileName = "new Idle Data")]
    public class PlayerIdleAction : Action
    {
        #region PROPERTIES
        
        private static readonly int Speed = Animator.StringToHash("Speed");
        
        #endregion
                
        #region IMPLEMENTED FUNCTIONS
        
        // ReSharper disable Unity.PerformanceAnalysis
        public override void Onset(StateController controller)
        {
            Idle(controller);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public override void Updating(StateController controller)
        {
            SetAnimation(controller);
        }        
         
        #endregion  
        
        #region PRIVATE FUNCTIONS
        
        private void Idle(StateController controller)
        {
            controller.data.rigidbody.velocity = Vector3.zero;
        }
        
        private void SetAnimation(StateController controller)
        {
            if (Mathf.Abs(VerticalInput.Value) >= Mathf.Abs(HorizontalInput.Value))
                controller.data.animator.SetFloat(Speed, Mathf.Abs(VerticalInput.Value));
            
            if (Mathf.Abs(HorizontalInput.Value) > Mathf.Abs(VerticalInput.Value))
                controller.data.animator.SetFloat(Speed, Mathf.Abs(HorizontalInput.Value));
        }

        private void Detector(StateController controller)
        {
            
        }
        
        #endregion
    }
}