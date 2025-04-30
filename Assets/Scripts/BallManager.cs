using UnityEngine;
using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    public static BallManager instance;

    [Header("Currently Equipped Ball")]
    public EquippedBallData currentBall;

    private bool redBallPurchased = false;

    public Button buyRedBallButton;

    private void Awake()
    {
        // Singleton pattern to ensure only one BallManager exists
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

    public bool TryPurchaseRedBall(EquippedBallData redBallData, int cost)
    {
        if (redBallPurchased)
        {
            Debug.Log("Red Ball already purchased!");
            return false;
        }

        if (GameManager.instance.money >= cost)
        {
            // Purchase the Red Ball
            GameManager.instance.money -= cost;
            GameManager.instance.UpdateUI();

            // Equip the new ball
            currentBall = redBallData;
            redBallPurchased = true;

            Debug.Log("Red Ball purchased and equipped!");

            // Gray out the purchase button
            GrayOutPurchaseButton();

            return true;
        }


        Debug.Log("Not enough money to purchase Red Ball.");
        return false;
    }

    private void GrayOutPurchaseButton()
    {
        if (buyRedBallButton != null)
        {
            buyRedBallButton.interactable = false; // Disable the button
            ColorBlock colors = buyRedBallButton.colors;
            colors.normalColor = Color.gray; // Set color to gray
            buyRedBallButton.colors = colors;
        }
    }
    public EquippedBallData[] allAvailableBalls; // Assign in Inspector

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

[System.Serializable]
public class EquippedBallData
{
    public string ballName;
    public GameObject prefab;
    public float moneyMultiplier = 1f;
}



