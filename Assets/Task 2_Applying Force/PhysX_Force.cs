using UnityEngine;

public class PhysX_Force : MonoBehaviour
{
    public Rigidbody rb;
    public float force;

    void FixedUpdate()
    {
        rb.AddForce(Vector3.right * force);
    }
}
