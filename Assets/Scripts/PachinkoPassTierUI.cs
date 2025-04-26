using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PachinkoPassTierUI : MonoBehaviour
{
    public TextMeshProUGUI tierText;
    public Image rewardIcon;
    public TextMeshProUGUI unlockStatusText;

    public void SetupTier(int tierNumber, Sprite rewardSprite, bool isUnlocked)
    {
        tierText.text = $"Tier {tierNumber}";

        if (rewardSprite != null)
        {
            rewardIcon.gameObject.SetActive(true);
            rewardIcon.sprite = rewardSprite;
        }
        else
        {
            rewardIcon.gameObject.SetActive(false);
        }

        unlockStatusText.text = isUnlocked ? "Unlocked!" : "Locked";
    }
}

