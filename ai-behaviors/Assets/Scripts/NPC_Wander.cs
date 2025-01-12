using UnityEngine;
using UnityEngine.AI;


namespace Mubariz.AIBehaviors
{
    public class NPC_Wander : NPC_Component
    {
        public Area Area;

        float waitTime;
        float maxWaitTime = 3f;
        enum EState
        {
            Wandering,
            Waiting
        }

        [SerializeField]
        EState state = EState.Wandering;

        private void Start()
        {
            
            // In the start method we randomly start wandering or waiting of npcs
            int randomNum = Random.Range(0, 100);
            if (randomNum > 50)
            {
                state = EState.Wandering;
                ChangeState(EState.Wandering);
            }
            else
            {
                state = EState.Waiting;
                ChangeState (EState.Waiting);
            }

            SetRandomPosition();
        }
        private void Update()
        {
            if (state == EState.Wandering)
            {
                npc.Agent.autoBraking = true;              
                if (HasArrived())
                {
                    ChangeState(EState.Waiting);
                    state = EState.Waiting;
                }
            }
            
            if (state == EState.Waiting)
            {
                npc.Agent.autoBraking = false;
                waitTime -= Time.deltaTime;
                if (waitTime <= 0)
                {
                    ChangeState(EState.Wandering);
                }
            }
        }

        //Call function to set specific state
        void ChangeState(EState newState)
        {
            state = newState;
            if (state == EState.Wandering)   //if state set to  wandering then we call appropriate function
            {
                npc.Agent.isStopped = false;
                SetRandomPosition();
            }
            if (state == EState.Waiting)  //if state is set to waiting then we reset waitTime  to maxWaitTime
            {
                waitTime = maxWaitTime;
                npc.Agent.isStopped = true ;
            }
        }
        bool HasArrived()
        {
            return npc.Agent.remainingDistance <= npc.Agent.stoppingDistance;
        }

        void SetRandomPosition()
        {
            npc.Agent.SetDestination(Area.GetRandomPoint());
        }
    }

}