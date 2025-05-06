using UnityEngine;

public class BallPhysicsSpin : MonoBehaviour
{
    public float torqueAmount = 10f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Apply a small torque when spawned
        if (rb != null)
        {
            float randomDirection = Random.Range(0, 2) == 0 ? -1f : 1f;
            rb.AddTorque(torqueAmount * randomDirection);
        }
    }
}

