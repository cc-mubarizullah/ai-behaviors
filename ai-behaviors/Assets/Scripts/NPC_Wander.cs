using UnityEngine;


namespace Mubariz.AIBehaviors
{
    public class NPC_Wander : NPC_Component
    {
        public Area Area;
        private void Start()
        {
            SetRandomPosition();
        }
        private void Update()
        {
            if (HasArrived())
            {
                Debug.Log("player has arrived");
                SetRandomPosition();
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