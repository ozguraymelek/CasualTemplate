using ChaChaGames.Controllers;
using UnityEngine;

namespace ChaChaGames.FSMBuilder
{
    [CreateAssetMenu(menuName = "Finite State Machine/Player/Action/Walk", fileName = "new Walk Data")]
    public class PlayerWalkAction : Action
    {
        #region PROPERTIES
        
        private static readonly int Speed = Animator.StringToHash("Speed");
        
        #endregion
                
        #region IMPLEMENTED FUNCTIONS

        public override void Onset(StateController controller)
        {
            
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public override void Updating(StateController controller)
        {
            Walk(controller);
            Rotate(controller);
            SetAnimation(controller);
        }        
         
        #endregion  
        
        #region PRIVATE FUNCTIONS
        
        private void Walk(StateController controller)
        {
            controller.data.rigidbody.velocity = Vector3.forward * controller.data.walkSpeed * Time.fixedDeltaTime;
        }

        private void Rotate(StateController controller)
        {
            if (HorizontalInput.Value == 0 && VerticalInput.Value == 0) return;
            
            var direction = (Vector3.forward * VerticalInput.Value + Vector3.right * HorizontalInput.Value).normalized;
                    
            var rotGoal = Quaternion.LookRotation(direction);
                    
            controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, rotGoal, controller.data.rotateSpeed * Time.deltaTime);
        }

        private void SetAnimation(StateController controller)
        {
            if (Mathf.Abs(VerticalInput.Value) > Mathf.Abs(HorizontalInput.Value))
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