using UnityEngine;

public class Torque : MonoBehaviour
{
    public float force = 1.597961f;
    public float mass;
    public Transform flag;
    private float velocity;
    public float acceleration;
    public float radius;
    public float torque;
    public float inertia;
    private float rotation;
    private float maxAngularVelocity = 7;

    void Start()
    {
        rotation = transform.rotation.y;
        radius = (flag.GetComponent<Renderer>().bounds.size.x); // TODO: Calculate the radius
    }
    void FixedUpdate()
    {
        rotation += AddTorque();
        
        if (rotation > maxAngularVelocity)
        {
            rotation = maxAngularVelocity;
        }

        transform.Rotate(new Vector3(0, rotation, 0)); // TODO: Rotate the spinner using the calculated angular velocity from AddTorque()
    }

    private float AddTorque()
    {
        torque = force * radius * Mathf.Sin(90);

        inertia = (mass * (radius * radius))/3; // TODO: Calculate moment of inertia
        
        // TIP: Constant acceleration = 0.612245
        acceleration = torque / inertia; // TODO: Calculate acceleration

        velocity += (acceleration) * Time.deltaTime * Time.deltaTime; // TODO: Calculate angular velocity
        
        return velocity;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector3(radius, 0, 0), new Vector3(0.5f,0.5f,0.5f));
    }
    
}
