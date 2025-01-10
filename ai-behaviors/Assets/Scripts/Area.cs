using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Mubariz.AIBehaviors
{
    public class Area : MonoBehaviour
    {
        public float Radius = 20f;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, Radius);
        }

        public Vector3 GetRandomPoint()
        {
            // gets a random direction inside a sphere of Unit (1) and thus multiply it by our radius
            Vector3 randomDirection = Random.insideUnitSphere * Radius;
            randomDirection.y = 0f;   // set the value y to 0 so agent don't move up or down

            Vector3 randomPoint = transform.position + randomDirection;  //now adding player position to the point we get inside the sphere

            NavMeshHit Hit;

            Vector3 finalPosition = transform.position;

            float maxDistForSamplePos = 5f;
            int areaMask = 1;  // refers to the base walkable area
            

            //CHECKING FOR VALID POINT ON NAVMESH SURFACE NOT ON OBSTACLE

            //check if that random point is on valid point if not if check again on maxDisSample 
            if (NavMesh.SamplePosition(randomPoint, out Hit, maxDistForSamplePos, areaMask))
            {
                finalPosition = Hit.position;  // if found valid point set the final pos to that point 
            }

            return finalPosition;   //otherwise don't move
        }
    }

    

}
