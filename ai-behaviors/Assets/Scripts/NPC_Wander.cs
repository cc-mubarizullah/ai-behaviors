using UnityEngine;


namespace Mubariz.AIBehaviors
{
    public class NPC_Wander : NPC_Component
    {
        
        public Area Area;

        float waitTime;
        float currentWanderTime;

        float leastWaitTime = 3f;
        float maxRandomWaitTime = 5f;
        float maxWanderTime = 10f;
        enum EState
        {
            Wandering,
            Waiting
        }

        [SerializeField]
        EState state = EState.Wandering;

        private void Start()
        {
            SetRandomStateAtStart();
        }


        private void Update()
        {
            CheckState();
        }

        void CheckState()
        {
            if (npc.Wander == false)
            {
                return;
            }
            if (state == EState.Wandering)
            {
                currentWanderTime -= Time.deltaTime;

                //PLAYER HAS REACHED DESTINATION
                if (HasArrived() || currentWanderTime <= 0)
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


        //TO SET SPECIFIC STATE
        void ChangeState(EState newState)
        {
            state = newState;

            //if state is WANDERING
            if (state == EState.Wandering)   
            {
                currentWanderTime = maxWanderTime;
                npc.Agent.isStopped = false;
                SetRandomPosition();
            }

            //if state is WAITING
            if (state == EState.Waiting)  
            {
                waitTime = leastWaitTime + Random.Range(0,maxRandomWaitTime);
                npc.Agent.isStopped = true;
            }
        }


        void SetRandomStateAtStart()
        {
            if (npc.Wander == true)
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
                    ChangeState(EState.Waiting);
                }
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