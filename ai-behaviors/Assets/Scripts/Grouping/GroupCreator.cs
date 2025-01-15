using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mubariz.AIBehaviors;

namespace Mubariz.AIBehaviors
{
    public class GroupCreator : MonoBehaviour
    {
        [SerializeField]
        Formation[] formations;

        [SerializeField]
        Area[] areas;

        [SerializeField]
        NPC NPC_Leader_Prefab;

        [SerializeField]
        NPC NPC_Follower_Prefab;

        [SerializeField]
        int minGroupSize = 3;

        [SerializeField]
        int maxGroupSize = 3;

        [SerializeField]
        int groupCount = 5;

        GroupManager groupManager;


        #region UNITY METHOD

        private void Start()
        {
            Debug.Log("start");
            groupManager = GetComponent<GroupManager>();

            for (int i = 0; i < groupCount ; i++)
            {
                CreateRandomGroup();
            }
        }




        #endregion
        Area GetRandomArea()
        {
            return areas[Random.Range(0, areas.Length)];
        }

        Formation GetRandomFormation()
        {
            return formations[Random.Range(0, formations.Length)];
        }

        void CreateRandomGroup()
        {
            Debug.Log("jsklfgh");
            Group group = groupManager.CreateGroup();

            group.DrawGizmos = true;

            Area area = GetRandomArea();
            Formation formation = GetRandomFormation();

            Vector3 leaderPosition = area.GetRandomPoint();
            Quaternion leaderRotation = Quaternion.Euler(0.0f, Random.Range(0, 360f), 0.0f);

            NPC leader = Instantiate(NPC_Leader_Prefab , leaderPosition, leaderRotation);

            leader.GetComponent<NPC_Wander>().Area = area;

            group.AddMemeber(leader);
            group.Formation = formation;

            int followerCount = Random.Range(minGroupSize, maxGroupSize);

            for (int i = 0; i < followerCount; i++)
            {
                NPC follower = Instantiate(NPC_Follower_Prefab, leaderPosition, leaderRotation);

                group.AddMemeber(follower);

                Vector3 memberPositionInFormation = group.GetPositionInGroup(follower);

                follower.transform.position = memberPositionInFormation;
            }
        }
    }

}
