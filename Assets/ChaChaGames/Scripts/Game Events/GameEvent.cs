using System;
using System.Collections.Generic;
using ExtEvents.OdinSerializer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ChaChaGames.Scripts.Game_Events
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        [ShowInInspector]
        private readonly List<GameEventListener> eventListeners = 
            new List<GameEventListener>();
        
        [Button]
        public void Raise()
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised();
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!eventListeners.Contains(listener))
            {
                eventListeners.Add(listener);
            }
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}