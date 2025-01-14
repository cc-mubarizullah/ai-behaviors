using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Mubariz.AIBehaviors
{
    public class NPC_Group_Member : NPC_Component
    {
        #region UNITY METHODS

        private void Update()
        {
            if (npc.Group == null)
            {
                npc.Wander = true;
                return;
            }

            if (npc.Group.IsLeader(npc))  // if it is leader than make him wander
            {
                npc.Wander = true;
            }
            else       //if not than get its position
            {
                Vector3 position = npc.Group.GetPositionInGroup(npc);
                npc.Agent.SetDestination(position);
                npc.Agent.isStopped = false;

                npc.Wander = false;
            }
        }


        #endregion
    }
}

