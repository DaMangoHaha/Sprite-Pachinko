using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallShopItem : MonoBehaviour
{
    public BallData ballData; // Reference to the BallData script attached to the same GameObject
    public Button purchaseButton;
    public TextMeshProUGUI priceText;
    public AudioClip purchaseSound;
    private AudioSource audioSource;

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

            // Plays a purchase sound to ensure player bought the ball
            if (purchaseSound != null)
                audioSource.PlayOneShot(purchaseSound);

            Debug.Log(ballData.ballName + " purchased and equipped!");

            purchaseButton.interactable = false;
        }
        else
        {
            Debug.Log("Not enough money to purchase " + ballData.ballName);

            purchaseButton.interactable = true;
        }
    }
}

