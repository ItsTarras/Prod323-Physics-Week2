using UnityEngine;

public class PhysX_Torque : MonoBehaviour
{
    public Rigidbody rb;
    public float torque;
    void FixedUpdate(){
        rb.AddTorque(new Vector3(0,1,0) * torque, ForceMode.Force);
    }
}
