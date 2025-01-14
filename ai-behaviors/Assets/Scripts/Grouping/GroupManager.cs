using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Mubariz.AIBehaviors
{
    public class GroupManager : MonoBehaviour
    {
        //LIST OF ALL THE GROUPS
        [SerializeField]
        List<Group> Groups = new List<Group>();


        [ContextMenu("Create New Group")]

        // THIS METHOD IS RESPONSIBLE FOR CREATING A NEW GROUP AS THE CHILD OF THIS GAMEOBJECT
        public Group CreateGroup()
        {
            GameObject obj = new GameObject($"Group{Groups.Count + 1}"); //make new gameobject named Group and new count of group

            obj.transform.parent = transform; // set it the children of this gameobject

            Group group = obj.AddComponent<Group>();  // add group script on that gameobject

            Groups.Add(group); // add that group script to the list of groups

            return group; // return the group
        }


    }

}
