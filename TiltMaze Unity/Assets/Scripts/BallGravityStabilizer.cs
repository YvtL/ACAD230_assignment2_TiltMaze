using UnityEngine;

public class BallGravityStabilizer : MonoBehaviour
{
    private Rigidbody rb;
    public float downwardForce = 5f; // Adjust this value as needed

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(Collision collision)
    {
        // Apply a small downward force to keep the ball grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.AddForce(Vector3.down * downwardForce, ForceMode.Acceleration);
        }
    }
}
