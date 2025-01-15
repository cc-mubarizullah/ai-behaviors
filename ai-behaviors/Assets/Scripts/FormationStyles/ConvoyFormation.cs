using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mubariz.AIBehaviors
{
    [CreateAssetMenu(menuName ="Game/Formation/ConveyFormation")]
    public class ConvoyFormation : Formation
    {
        [SerializeField]
        float Spacing = 3f;

        public override Vector3 GetPosition(NPC npc, Group group)
        {
            if (group.IsLeader(npc))
            {
                return npc.Position;
            }

            int memberIndex = group.Members.IndexOf(npc);

            if (memberIndex <= 0)
            {
                throw new InvalidOperationException("NPC cannot determine a leader. Ensure the group is correctly configured.");
            }

            NPC leader = group.Members[memberIndex - 1];   //The "leader" is the NPC just ahead in the group (at memberIndex - 1).

            float distanceToLeader = Vector3.Distance(npc.Position, leader.Position);  

            if (distanceToLeader < Spacing)  //if npc already in required spacing distance don't move it set its position that its currently holding
            {
                return npc.Position;
            }
            else               // if not
            {
                Vector3 direction = (npc.Position - leader.Position).normalized;  // normalized property gives us the direction only not magntude from npc to the leader  

                // we also put leader.Position to minus so means its direction is backward
                                                       

                Vector3 targetPosition = leader.Position + direction * Spacing;  // now add the direction which will have negative direction to the leader position multiply by spacing

                return AdjustPosition(targetPosition, leader.Position);
            }
        }
    }
}

