using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mubariz.AIBehaviors
{
    public class NPC_Animator : NPC_Component
    {
        private void Update()
        {

            float forwardSpeed = Vector3.Dot(npc.Velocity, npc.transform.forward);// if +, player moving forward...if -, player moving backward, ....if 0 player is standard
            float rightSpeed = Vector3.Dot(npc.Velocity, npc.transform.right); // if +, player moving right...if -, player moving left, ....if 0 player is standard

            npc.Animator.SetFloat("Speed", forwardSpeed);
            npc.Animator.SetFloat("StrafeSpeed", rightSpeed);
        }
    }

}
