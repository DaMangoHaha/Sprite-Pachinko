using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    public static BallManager instance;

    [Header("Currently Equipped Ball")]
    public EquippedBallData currentBall;

    [Header("Available Balls")]
    public EquippedBallData[] allAvailableBalls; // Assign in Inspector
    public Button[] purchaseButtons; // Match order with allAvailableBalls

    private HashSet<string> purchasedBalls = new HashSet<string>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void TryPurchaseBall(int ballIndex, int cost)
    {
        if (ballIndex < 0 || ballIndex >= allAvailableBalls.Length) return;

        EquippedBallData ballData = allAvailableBalls[ballIndex];

        if (purchasedBalls.Contains(ballData.ballName))
        {
            Debug.Log($"{ballData.ballName} already purchased!");
            return;
        }

        if (GameManager.instance.money >= cost)
        {
            GameManager.instance.money -= cost;
            GameManager.instance.UpdateUI();

            currentBall = ballData;
            purchasedBalls.Add(ballData.ballName);
            Debug.Log($"{ballData.ballName} purchased and equipped!");

            if (purchaseButtons != null && ballIndex < purchaseButtons.Length)
            {
                purchaseButtons[ballIndex].interactable = false;
                ColorBlock colors = purchaseButtons[ballIndex].colors;
                colors.normalColor = Color.gray;
                purchaseButtons[ballIndex].colors = colors;
            }
        }
        else
        {
            Debug.Log("Not enough money to purchase this ball.");
        }
    }

    public void EquipBallByName(string ballName)
    {
        foreach (EquippedBallData ball in allAvailableBalls)
        {
            if (ball.ballName == ballName)
            {
                currentBall = ball;
                break;
            }
        }
    }
}



