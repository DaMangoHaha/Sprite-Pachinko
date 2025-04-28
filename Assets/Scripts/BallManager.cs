using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager instance;

    public List<BallData> balls = new List<BallData>();
    public BallData currentBall;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void SetCurrentBall(int index)
    {
        if (index >= 0 && index < balls.Count)
        {
            currentBall = balls[index];
            Debug.Log("Equipped Ball: " + currentBall.ballName);
        }
    }
}

