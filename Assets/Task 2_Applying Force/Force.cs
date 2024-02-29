using UnityEngine;

public class Force : MonoBehaviour
{
    public float force;
    public float mass;
    public Vector3 direction;

    private Vector3 velocity;
    private float acceleration;

    void FixedUpdate()
    {
        transform.position += AddForce();
    }

    private Vector3 AddForce()
    {
        acceleration = (force/mass); // TODO: Calculate acceleration
        velocity += new Vector3(direction.x, direction.y, direction.z) * acceleration * Time.deltaTime * Time.deltaTime; // TODO: Calculate linear velocity
        return velocity;
    }
}
