using Mubariz.AIBehaviors;
using UnityEngine;

namespace Mubariz.AIBehaviors
{
    [CreateAssetMenu(menuName = "Game/Formation/Line Formation")]
    public class LineFomation : Formation
    {
        [SerializeField]
        float Spacing = 3f;

        public override Vector3 GetPosition(NPC npc, Group group)
        {
            if (group.IsLeader(npc))
            {
                return npc.Position;
            }

            NPC leader = group.GetLeader();

            Vector3 leaderRight = Vector3.Cross(Vector3.up, leader.Direction).normalized;  //gives us the direction prependicular vector between forward and up

            Vector3 position = leader.Position - leader.Direction * Spacing;    // 3 units backward from leader position     

            float formationWidth = (group.FollowerCount - 1) * Spacing;      //numbers of npc except leader multiply by spacing gives us the total lenght of the line

            position -= leaderRight * formationWidth * 0.5f;   //from 3 units back of leader we half of the left side

            position += leaderRight * Spacing * group.GetFollowerIndex(npc);   //and now from that position we do exactly the same as column formation but in right side

// suppose for follower npc = left most position * 3  * 2 ;
             
            return AdjustPosition(position, leader.Position);   
        }
    }

}
