using System.Linq;
using Mubariz.AIBehaviors;
using UnityEngine;

public class NPC_Generator : MonoBehaviour
{
    
    [System.Serializable]
    struct NPC_In_Area
    {
        public Area area;
        public NPC playerPrefab;
        public int count;
    }

    [SerializeField]
    NPC_In_Area[] prefabInArea;

    private void Start()
    {
        foreach (var prefabData in prefabInArea)
        {
            for (int i = 0; i < prefabData.count; i++)
            {
                Vector3 pos = prefabData.area.GetRandomPoint();
                Quaternion rot = Quaternion.Euler(0f, (Random.Range(0f, 360f)), 0f);

                NPC npc = Instantiate(prefabData.playerPrefab, pos, rot);

                npc.GetComponent<NPC_Wander>().Area = prefabData.area;
            }
        }
    }

}
