using System.Collections;
using System.Collections.Generic;
using Mubariz.AIBehaviors;
using UnityEngine;

namespace Mubariz.AIBehaviors
{
    /// <summary>
    ///             THIS SCRIPT IS RESPOSIBLE FOR PROVIDING ITS DERIVED CLASSES THE NPC COMPONENT
    /// </summary>
    public class NPC_Component : MonoBehaviour
    {
        protected NPC npc;

        private void Awake()
        {
            npc = GetComponentInParent<NPC>();
        }
    }

}
