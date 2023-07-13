using System;
using ChaChaGames.FSMBuilder;
using ChaChaGames.Scripts.Data_Containers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ChaChaGames.Controllers
{
    public class StateController : MonoBehaviour
    {
        [TabGroup("State"),DisableIn(PrefabKind.All)] 
        public BaseState CurrentState;
        [TabGroup("State")] 
        public BaseState InitialState;

        [TabGroup("Data")] 
        public PlayerData data;

        #region EVENT FUNCTIONS

        private void Awake()
        {
            CurrentState = InitialState;
            CurrentState.Onset(this);
        }
        
        private void FixedUpdate()
        {
            CurrentState.Updating(this);
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, data.Range);

            Vector3 viewAngle01 = DirectionFromAngle(transform.eulerAngles.y, -data.CurrentFOV / 2);
            Vector3 viewAngle02 = DirectionFromAngle(transform.eulerAngles.y, data.CurrentFOV / 2);

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position,
                transform.position + viewAngle01 * data.Range);
            Gizmos.DrawLine(transform.position,
                transform.position + viewAngle02 * data.Range);

            if (data.HasTarget)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, data.CurrentTarget.GetTransform().position);
            }
        }
        
        #endregion
        
        #region PRIVATE FUNCTIONS
        private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
        {
            angleInDegrees += eulerY;

            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }
        #endregion
    }
}