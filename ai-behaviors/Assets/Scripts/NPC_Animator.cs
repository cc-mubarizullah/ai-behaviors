using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mubariz.AIBehaviors
{
    public class NPC_Animator : NPC_Component
    {
        private void Update()
        {
            npc.Animator.SetFloat("Speed", npc.CurrentSpeed);
        }
    }

}
