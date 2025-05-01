using UnityEngine;

public class RewardSquare : MonoBehaviour
{
    public int moneyValue = 1;
    public int expValue = 0;

    private void Start()
    {
        SetEXPValue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            // Try to get the BallBehavior component
            BallBehavior ball = collision.GetComponent<BallBehavior>();
            float moneyMultiplier = 1f;
            float expMultiplier = 1f;

            if (ball != null && ball.ballData != null)
            {
                moneyMultiplier = ball.ballData.moneyMultiplier;
                expMultiplier = ball.ballData.expMultiplier;
            }

            // Apply money multiplier
            float totalMoney = moneyValue * moneyMultiplier;
            GameManager.instance.AddMoney(Mathf.RoundToInt(totalMoney));

            // Apply score (unchanged logic)
            int scoreToAdd = 0;
            switch (moneyValue)
            {
                case 2:
                    scoreToAdd = 20;
                    break;
                    case 3:
                    scoreToAdd = 30;
                    break;
                case 5:
                    scoreToAdd = 50;
                    break;
                case 10:
                    scoreToAdd = 100;
                    break;
                case 1:
                default:
                    scoreToAdd = 10;
                    break;
            }
            GameManager.instance.AddScore(scoreToAdd);

            // Apply EXP multiplier
            float totalEXP = expValue * expMultiplier;
            LevelManager.instance.AddEXP(Mathf.RoundToInt(totalEXP));

            // Destroy the ball
            Destroy(collision.gameObject);
        }
    }

    private void SetEXPValue()
    {
        switch (moneyValue)
        {
            case 1:
                expValue = 1;
                break;
            case 2:
                expValue = 2;
                break;
                case 3:
                    expValue = 3;
                break;
            case 5:
                expValue = 5;
                break;
            case 10:
                expValue = 10;
                break;
            default:
                expValue = 0;
                break;
        }
    }
}

