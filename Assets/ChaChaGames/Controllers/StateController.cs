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
        public BaseContainer data;

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

        #endregion
    }
}