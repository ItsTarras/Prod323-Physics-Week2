using UnityEngine;

public class BoundingSphere : MonoBehaviour
{
    public GameObject sphereA;
    public GameObject sphereB;

    [Header("Sphere Bounds Settings")]
    [Range(1, 10)] public float boundingSphereARadius;
    [Range(1, 10)] public float boundingSphereBRadius;

    public float sumOfRadii;
    public float distance;

    public Vector3 sphereDistance;

    void FixedUpdate(){
        CheckSphereCollission();
    }

    void CheckSphereCollission(){

        sumOfRadii = boundingSphereARadius + boundingSphereBRadius;

        sphereDistance = sphereB.transform.position - sphereA.transform.position;

        distance = (Mathf.Max(Mathf.Abs(sphereDistance.x), Mathf.Abs(sphereDistance.y), Mathf.Abs(sphereDistance.z))); // TODO: Calculate distance between the 2 spheres

        if(distance < sumOfRadii){
            Debug.Log("Colliding...");
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(sphereA.transform.position, boundingSphereARadius); // TODO: Calculate radius, must be hugging the sphere tightly at size 1

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(sphereB.transform.position, boundingSphereBRadius); // TODO: Calculate radius, must be hugging the sphere tightly at size 1
    }
}
