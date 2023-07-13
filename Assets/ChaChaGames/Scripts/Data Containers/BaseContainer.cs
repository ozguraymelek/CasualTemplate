using Sirenix.OdinInspector;
using UnityEngine;

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
        
        #endregion
    }
}