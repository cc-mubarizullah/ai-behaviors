using System.Collections;
using System.Collections.Generic;
using Mubariz.AIBehaviors;
using UnityEngine;

namespace Mubariz.AIBehaviors
{
    /// <summary>
    ///             THIS SCRIPT IS BASE CLASS OF NPC
    /// </summary>
    public class NPC_Component : MonoBehaviour
    {
        protected NPC npc;

        private void Awake()
        {
            npc = GetComponentInParent<NPC>();
        }

        public virtual void SetNPC(NPC npc)
        {
            this.npc = npc;                 // the assigned npc in this function will be the npc that this script will use
        }
    }

}
