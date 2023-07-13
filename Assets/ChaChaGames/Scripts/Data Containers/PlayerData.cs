using ChaChaGames.Scripts.Collisions;
using ChaChaGames.Scripts.RefValue;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ChaChaGames.Scripts.Data_Containers
{
    public class PlayerData : BaseContainer
    {
        [TabGroup("B","Input"),GUIColor(0f,1f,0f,1f)]
        [ShowInInspector] public FloatRef VerticalInput;
        [TabGroup("B","Input"),GUIColor(0f,1f,0f,1f)]
        [ShowInInspector] public FloatRef HorizontalInput;
        [TabGroup("B","Input"),GUIColor(0f,1f,0f,1f)]
        [ShowInInspector] public Vector3Ref MovementVector;
        
        [TabGroup("C", "Runtime")] [ShowInInspector]
        public IHittable CurrentTarget;
        [TabGroup("C", "Runtime")] 
        public int activeTargetCount;
        [TabGroup("C", "Runtime")]
        public Collider[] detectedTargets = new Collider[20];
    }
}