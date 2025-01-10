using System.Collections;
using System.Collections.Generic;
using Mubariz.AIBehaviors;
using UnityEngine;

namespace Mubariz.AIBehaviors
{
    public class NPC_Component : MonoBehaviour
    {
        protected NPC npc;

        private void Awake()
        {
            npc = GetComponentInParent<NPC>();
        }
    }

}
