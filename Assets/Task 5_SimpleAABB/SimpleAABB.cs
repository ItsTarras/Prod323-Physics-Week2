using Unity.VisualScripting;
using UnityEngine;

public class SimpleAABB : MonoBehaviour
{
    public GameObject cubeA;
    public GameObject cubeB;

    [Header("Cube Bounds Settings")]
    [Range(1, 10)] public float boundingCubeASize;
    [Range(1, 10)] public float boundingCubeBSize;

    public float cubeRadiusSum;
    public Vector3 cubeDistance;
    public float distance;

    void FixedUpdate(){
        if(CheckAABBCollision()){
            Debug.Log("Colliding...");
        }
    }

    bool CheckAABBCollision(){
        // TODO: Implement AABB collision detection
        cubeRadiusSum = (boundingCubeASize + boundingCubeBSize) / 2 ;

        cubeDistance = cubeB.transform.position - cubeA.transform.position;


        bool xCollision = false;
        bool yCollision = false;
        bool zCollision = false;

        if (Mathf.Abs(cubeDistance.x) < cubeRadiusSum) {
            xCollision = true; ; // TODO: Calculate distance between the 2 spheres
        }
        if (Mathf.Abs(cubeDistance.y) < cubeRadiusSum)
        {
            yCollision = true;
        }
        if (Mathf.Abs(cubeDistance.z) < cubeRadiusSum)
        {
            zCollision = true;
        }

        // Check if all axes intersect
        return xCollision && yCollision && zCollision;
    }

    void OnDrawGizmos(){Gizmos.color = Color.blue;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(cubeA.transform.position, new Vector3(boundingCubeASize, boundingCubeASize, boundingCubeASize)); // TODO: Calculate collider size, must be hugging the cube tightly at size 1

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(cubeB.transform.position, new Vector3(boundingCubeBSize, boundingCubeBSize, boundingCubeBSize));// TODO: Calculate radius, must be hugging the sphere tightly at size 1
    }
}
