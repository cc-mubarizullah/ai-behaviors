
using UnityEngine;
using UnityEngine.AI;

namespace Mubariz.AIBehaviors
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]

    [SelectionBase]
    public class NPC : MonoBehaviour
    {


        //making them public because we have to use them somewhere else
        [HideInInspector]
        public NavMeshAgent Agent;
        [HideInInspector]
        public Animator Animator;

        public Group Group = null;

        public bool Wander = false;

        public bool Alive = true;

        // making speed property
        public float CurrentVelocity
        {
            get
            {
                return Agent.velocity.magnitude;
            }
        }

        //Property to get the FACE direction of NPC
        public Vector3 Direction { get; private set;} = Vector3.forward; //by default  

        //Property to get the POSITION of the player
        public Vector3 Position => transform.position;


        //getting member components
        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            Animator = GetComponent<Animator>();
        }

        private void Update()
        {
            // if agent moves than update the direction vector3
            if (CurrentVelocity > 0)  
            {
                Direction = Agent.velocity.normalized;
            }
        }
    }

}
