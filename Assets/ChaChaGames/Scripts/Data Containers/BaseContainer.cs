using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChaChaGames.Scripts.Data_Containers
{
    public abstract class BaseContainer : MonoBehaviour
    {
        #region PROPERTIES
        
        [TabGroup("A","Characteristics")] 
        public new string name;
        
        [TabGroup("A","Characteristics")] 
        public float walkSpeed;
        [TabGroup("A","Characteristics")] 
        public float runSpeed;
        [TabGroup("A","Characteristics")] 
        public float rotateSpeed;
        
        [TabGroup("A","Physic")] 
        public new Collider collider;
        [TabGroup("A","Physic")] 
        public new Rigidbody rigidbody;

        [TabGroup("A", "Art")] 
        public Animator animator;
        
        [TabGroup("C", "Runtime")] 
        public bool HasTarget;

        [FormerlySerializedAs("Radius")] [TabGroup("C", "Attack")] [Tooltip("radius of target area")]
        public float Range;
        [TabGroup("C", "Attack")] [Tooltip("radius of target area")][Range(0,360)]
        public float FOV;
        [FormerlySerializedAs("FOV")] [TabGroup("C", "Attack")] [Tooltip("radius of target area")][Range(0,360)][Indent(2)]
        public float CurrentFOV;

        
        #endregion
    }
}