using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float mass;
    private Vector3 velocity;
    private Vector3 gravitationalForce;
    private const float gravity = -9.81f; // TODO: Set gravitational acceleration

    void Start()
    {
        velocity = Vector3.zero; // At rest
    }

    void FixedUpdate()
    {
        transform.position += AddGravitationalForce();
    }

    private Vector3 AddGravitationalForce()
    {
        gravitationalForce = new Vector3(0, gravity, 0); // TODO: Calculate gravitational force
        velocity += gravitationalForce * Time.deltaTime * Time.deltaTime;
        return velocity; 
    }
}
