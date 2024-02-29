using UnityEngine;

public class ComplexAABB : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;

    private Vector3 objectABoundSize;
    private Vector3 objectBBoundSize;
    private Vector3 objectACenter;
    private Vector3 objectBCenter;

    private Mesh meshA;
    private Mesh meshB;
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    private float minZ;
    private float maxZ;
    public Vector3 radiusSize;
    public Vector3 objectDistance;


    void Start(){
        meshA = objectA.GetComponent<MeshFilter>().mesh;
        meshB = objectB.GetComponent<MeshFilter>().mesh;

        objectABoundSize = ComputeBoundingBox(meshA, out objectACenter);
        objectBBoundSize = ComputeBoundingBox(meshB, out objectBCenter);
    }

    void FixedUpdate(){
        if(CheckAABBCollision()){
            Debug.Log("Colliding...");
        }
    }

    Vector3 ComputeBoundingBox(Mesh m, out Vector3 centerPoint){
        Vector3 minBounds = Vector3.zero;
        Vector3 maxBounds = Vector3.zero;
        minX = Mathf.Infinity;
        maxX = Mathf.NegativeInfinity;
        minY = Mathf.Infinity;
        maxY = Mathf.NegativeInfinity;
        minZ = Mathf.Infinity;
        maxZ = Mathf.NegativeInfinity;

        foreach(Vector3 vertex in m.vertices){
            //Check the minimums
            if (vertex.x < minX)
            {
                minX = vertex.x;
            }

            if (vertex.y < minY)
            {
                minY = vertex.y;
            }

            if (vertex.z < minZ)
            {
                minZ = vertex.z;
            }


            //Check the maximums
            if (vertex.x > maxX)
            {
                maxX = vertex.x;
            }

            if (vertex.y > maxY)
            {
                maxY = vertex.y;
            }

            if (vertex.z > maxZ)
            {
                maxZ = vertex.z;
            }
        }


        minBounds = new Vector3(minX, minY, minZ);
        maxBounds = new Vector3(maxX, maxY, maxZ);
        centerPoint = (minBounds + maxBounds) * 0.5f;
        return maxBounds - minBounds;
            
    }

    bool CheckAABBCollision(){
    // TODO: Implement AABB collision detection
        radiusSize = (objectABoundSize + objectBBoundSize) / 2;

        objectDistance = objectB.transform.position - objectA.transform.position;


        bool xCollision = false;
        bool yCollision = false;
        bool zCollision = false;

        if (Mathf.Abs(objectDistance.x) < radiusSize.x)
        {
            xCollision = true; ; // TODO: Calculate distance between the 2 spheres
        }
        if (Mathf.Abs(objectDistance.y) < radiusSize.y)
        {
            yCollision = true;
        }
        if (Mathf.Abs(objectDistance.z) < radiusSize.z)
        {
            zCollision = true;
        }

        // Check if all axes intersect
        return xCollision && yCollision && zCollision;
 
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(objectA.transform.position + objectACenter, objectABoundSize);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(objectB.transform.position + objectBCenter, objectBBoundSize);
    }
}
