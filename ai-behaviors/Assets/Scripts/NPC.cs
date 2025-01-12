
using UnityEngine;
using UnityEngine.AI;

namespace Mubariz.AIBehaviors
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class NPC : MonoBehaviour
    {
        //making them public because we have to use them somewhere else
        [HideInInspector]
        public NavMeshAgent Agent;
        [HideInInspector]
        public Animator Animator;

        // making speed property
        public float CurrentVelocity
        {
            get
            {
                return Agent.velocity.magnitude;
            }
        }

        //getting member components
        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            Animator = GetComponent<Animator>();
        }
    }

}
