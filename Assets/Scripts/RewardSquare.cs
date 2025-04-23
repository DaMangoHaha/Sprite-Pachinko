using UnityEngine;

public class RewardSquare : MonoBehaviour
{
    public int moneyValue = 1; // Can be 0, 1, 5, 10

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            // Give money
            GameManager.instance.AddMoney(moneyValue);

            // Gives score based on money value
            int scoreToAdd = 0;
            switch (moneyValue)
            {
                case 1:
                    scoreToAdd = 10;
                    break;
                case 5:
                    scoreToAdd = 50;
                    break;
                case 10:
                    scoreToAdd = 100;
                    break;
                case 0:
                default:
                    scoreToAdd = 0;
                    break;
            }
            GameManager.instance.AddScore(scoreToAdd);

            // Destroys the ball
            Destroy(collision.gameObject);
        }
    }
}
