using Mubariz.AIBehaviors;
using UnityEngine;

[CreateAssetMenu(menuName ="Game/Formation/Line Formation")]
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

        Vector3 leaderRight = Vector3.Cross(Vector3.up, leader.Direction).normalized;

        Vector3 position = leader.Position - leader.Direction * Spacing;

        float formationWidth = (group.FollowerCount - 1) * Spacing;

        position -= leaderRight * formationWidth * 0.5f;

        position += leaderRight * Spacing * group.GetFollower(npc);

        return AdjustPosition(position, leader.Position);
    }
}
