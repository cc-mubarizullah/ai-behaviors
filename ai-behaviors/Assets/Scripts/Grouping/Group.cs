using Mubariz.AIBehaviors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Mubariz.AIBehaviors
{
    /// <summary>
    /// 
    ///     THIS SCRIPT IS RESPONSIBLE FOR HANDLING GROUP MEMBERS, IT WILL TAKE FORMATION SO TO 
    /// 
    /// </summary>

    public class Group : MonoBehaviour
    {
        public bool DrawGizmos = false;

        [SerializeField]
        List<NPC> members = new List<NPC>();  //made a private list of NPCs

        public List<NPC> Members => members;  // made a property to access the list

        [SerializeField]
        Formation formation;  // private variable 

        public Formation Formation => formation;  //public property to access it

        public int MemberCount => members.Count;

        public int FollowerCount => Mathf.Max(0, MemberCount - 1); // we exclude 1 because there should be one leader

        public int GetFollower (NPC npc) => members.IndexOf(npc) - 1;  // to get the follower of any npc we subtract the npc number in list by one

        public bool IsLeader(NPC npc) => members.IndexOf(npc)==0;   // check if its the first index of the list




        #region UNITY METHODS

        private void Start()
        {
            InitilializeListMembersGroupToThis();          
        }

        
        private void Update()
        {
            RemovingDeadMembers();            
        }


        private void OnDrawGizmos()
        {
            if (formation == null || MemberCount == 0 || !DrawGizmos)
                return;

            foreach (NPC member in members)
            {
                Vector3 pos = GetPositionInGroup(member);  // get the position of member in the group

                Gizmos.color = Color.green;  

                if (IsLeader(member))
                {
                    Gizmos.color = Color.red;
                }
                float radiusOfGizmosSphere = 0.5f;
                Gizmos.DrawSphere(pos, radiusOfGizmosSphere);
            }

        }

        #endregion

        #region Members Management Methods

        public void AddMemeber(NPC npc)
        {
            members.Add(npc);
            npc.Group = this;
        }

        public void RemoveMember(NPC npc)
        {
            members.Remove(npc);
            npc.Group = null;
        }
        #endregion

        void InitilializeListMembersGroupToThis()
        {
            foreach (NPC npc in members)  //assign Group property of each npc in the list to this group
            {
                npc.Group = this;
            }
        }


        void RemovingDeadMembers()
        {

            for (int i = members.Count - 1; i >= 0; i--)  //we continously loop through all members from end
            {
                if (members[i].Alive == false)   //if any npc is NOT ALIVE
                {
                    members[i].Group = null;    //  we remove it from this group 
                    members.RemoveAt(i);         // and remove it from the list 
                }
            }
        }

        public NPC GetLeader()
        {
            if(members.Count >= 1)  // if members are greater than 1
            return members[0];       //return first member
            Debug.Log("There are less than 1 member in the group list");
            return null;           // otherwise return null
        }


        // for getting the position of npc in the formation
        public Vector3 GetPositionInGroup(NPC npc)
        {
             return formation.GetPosition(npc, this);
        }

        
        
    }

}
