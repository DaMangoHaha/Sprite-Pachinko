using UnityEngine;

public class RewardSquare : MonoBehaviour
{
    public int moneyValue = 1;  // The money value of the RewardSquare (can be 0, 1, 5, 10, or -10)
    public int expValue = 0;    // This will hold the EXP value based on the money value

    private void Start()
    {
        // Assign EXP based on the money value
        SetEXPValue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            // Gives money
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

            if (collision.CompareTag("Ball"))
                {
                    BallData equippedBall = BallManager.instance.currentBall;

                    // Calculate final money and EXP earned using multipliers
                    float moneyEarned = moneyValue * (equippedBall != null ? equippedBall.moneyMultiplier : 1f);
                    float expEarned = expValue * (equippedBall != null ? equippedBall.expMultiplier : 1f);

                    // Add money and score
                    GameManager.instance.AddMoney(Mathf.RoundToInt(moneyEarned));
                    GameManager.instance.AddScore(Mathf.RoundToInt(expEarned));

                    Destroy(collision.gameObject);
                }
            }

        }

        // Assigns EXP based on the money value
        private void SetEXPValue()
    {
        switch (moneyValue)
        {
            case 0:
                expValue = 1;  // No money, but gives 1 EXP
                break;
            case 1:
                expValue = 2;  // $1 square grants 2 EXP
                break;
            case 5:
                expValue = 5;  // $5 square grants 5 EXP
                break;
            case 10:
                expValue = 10; // $10 square grants 10 EXP
                break;
            case -10:
                expValue = 0;  // Negative value square grants 0 EXP
                break;
            default:
                expValue = 0;  // Default case if money value is not recognized
                break;
        }
    }
}
