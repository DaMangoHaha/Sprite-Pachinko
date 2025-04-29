using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallShopItem : MonoBehaviour
{
    public BallData ballData; // Reference to the BallData script attached to the same GameObject
    public Button purchaseButton;
    public TextMeshProUGUI priceText;

    private void Start()
    {
        if (priceText != null)
            priceText.text = "$" + ballData.cost;

        purchaseButton.onClick.AddListener(PurchaseBall);
    }

    void PurchaseBall()
    {
        if (GameManager.instance.money >= ballData.cost)
        {
            GameManager.instance.AddMoney(-ballData.cost);

            BallManager.instance.currentBall = new EquippedBallData
            {
                prefab = ballData.ballPrefab,
                moneyMultiplier = ballData.moneyMultiplier
            };

            Debug.Log(ballData.ballName + " purchased and equipped!");
        }
        else
        {
            Debug.Log("Not enough money to purchase " + ballData.ballName);
        }
    }
}

