using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace ChaChaGames.Scripts.Game_Events
{
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")] [ShowInInspector]
        public GameEvent Event;
        
        [Tooltip("Response to invoke when Event is raised.")] [ShowInInspector]
        public UnityEvent Response;
        
        private void Awake()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}