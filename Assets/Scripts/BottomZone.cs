using UnityEngine;

public class BottomZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            // Example: give 1 point and destroy the ball
            GameManager.instance.AddScore(1);
            Destroy(collision.gameObject);
        }
    }
}
