using ChaChaGames.Controllers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ChaChaGames.FSMBuilder
{
    [CreateAssetMenu(menuName = "Finite State Machine/Player/Action/Run", fileName = "new Run Data")]
    public class PlayerRunAction : Action
    {
        #region PROPERTIES
        
        private static readonly int Speed = Animator.StringToHash("Speed");
        
        #endregion

        #region IMPLEMENTED FUNCTIONS
        
        // ReSharper disable Unity.PerformanceAnalysis
        public override void Updating(StateController controller)
        {
            Run(controller);
            Rotate(controller);
            SetAnimation(controller);
        }

        #endregion

        #region PRIVATE FUNCTIONS

        private void Run(StateController controller)
        {
            controller.data.rigidbody.velocity = Vector3.forward * controller.data.runSpeed * Time.fixedDeltaTime;
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