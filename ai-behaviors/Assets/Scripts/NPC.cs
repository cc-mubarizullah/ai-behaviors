
using UnityEngine;
using UnityEngine.Events;

namespace Mubariz.AIBehaviors
{
    [RequireComponent(typeof(Animator))]

    [SelectionBase]
    public class NPC : MonoBehaviour
    {
        #region EVENTS

        public UnityAction<Vector3> SetDestination;

        #endregion

        //making them public because we have to use them somewhere elSE
        [HideInInspector]
        public Animator Animator;

        public float WalkSpeed = 3.5f;
        public float RunSpeed = 7f;

        public bool CanMove = true;

        public Group Group = null;

        //no longer need it here if an AI scripts needs it , it can get if from Npc WanderScript as it's the only one using it
        //public bool Wander = false;

        public bool Alive = true;

        public Vector3 Velocity = Vector3.zero;

        // making speed property
        /*public float CurrentVelocity
        {
            get
            {
                return Agent.velocity.magnitude;
            }
        }*/

        //Property to get the FACE direction of NPC
        public Vector3 Direction { get; private set;} = Vector3.forward; //by default  

        //Property to get the POSITION of the player
        public Vector3 Position => transform.position;

        #region UNITY EVENTS

        //getting member components
        private void Awake()
        {
            if (Animator == null)
            {
                Animator = GetComponent<Animator>();
            }
            if (Animator == null)
            {
                Debug.Log($"Animator component not found on {gameObject.name}");
            }
            
        }

        private void LateUpdate()
        {
            //we extrude the y component 
            Vector3 horizontalVelocity = new Vector3(Velocity.x, 0f, Velocity.z);

            float threshold = 3f;
            //if magnitude of that velocity is greater than threshold
            if (horizontalVelocity.magnitude > threshold)
            {
                // then we get the direction 
                Direction = horizontalVelocity.normalized;
            }
        }
        #endregion 
    }

}
