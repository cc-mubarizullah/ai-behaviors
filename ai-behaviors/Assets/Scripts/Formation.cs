using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace Mubariz.AIBehaviors
{
    public abstract class Formation : ScriptableObject
    {
        protected Vector3 AdjustPosition(Vector3 position, Vector3 leaderPosition)
        {
            if (NavMesh.Raycast(leaderPosition, position, out NavMeshHit hit, NavMesh.AllAreas)) // true : if hit obstacle  ... false: if not hit any obstacle
            {
                return hit.position;  // the ray has struct some obstacle 
            }
            return position;  // return the destination position
        }

        public abstract Vector3 GetPosition(NPC npc, Group group); 
        
    }

}
