using UnityEngine;

namespace Mubariz.AIBehaviors
{
    [CreateAssetMenu(menuName =("Game/Formation/Circular Fomation"))]
    public class CircularFormation : Formation
    {
        [SerializeField]
        float Radius = 3;

        public override Vector3 GetPosition(NPC npc, Group group)
        {
            if (group.IsLeader(npc))
            {
                return npc.Position;    
            }

            NPC leader = group.GetLeader();

            float angle =  group.GetFollowerIndex(npc) * 360f / group.FollowerCount;   //Angle = 0 * (360 / 3) = 0 degrees         Angle = 1 * (360 / 3) = 120 degrees      Angle = 2 * (360 / 3) = 240 degrees.


            Vector3 position = leader.Position + Quaternion.Euler(0f, angle, 0f) * leader.Direction * Radius;   //add this degree to the right direction from the player position

            return AdjustPosition(position, leader.Position);
        }
    }

}
