using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PachinkoPassManager : MonoBehaviour
{
    [System.Serializable]
    public class PassTier
    {
        public int tierNumber;
        public GameObject rewardBallPrefab; // null if it's an empty tier
        public bool isUnlocked = false;
    }

    public Transform tierListContainer; // ScrollView Content panel
    public GameObject tierEntryPrefab;  // Your UI prefab for each tier

    public List<PassTier> tiers = new List<PassTier>();

    private void Start()
    {
        GeneratePassTiers();
    }

    public void GeneratePassTiers()
    {
        for (int i = 1; i <= 16; i++)
        {
            PassTier newTier = new PassTier();
            newTier.tierNumber = i;

            // Assign ball prefabs to even tiers only
            if (i % 2 == 0)
            {
                string color = GetBallColorByTier(i);
                newTier.rewardBallPrefab = Resources.Load<GameObject>($"Balls/{color}Ball"); // Make sure to place prefabs in a Resources/Balls folder
            }

            // Check if tier should be unlocked based on player level
            int requiredLevel = i;
            if (LevelSystem.Instance.CurrentLevel >= requiredLevel)
            {
                newTier.isUnlocked = true;
            }

            tiers.Add(newTier);

            // Instantiate UI Entry
            GameObject tierUI = Instantiate(tierEntryPrefab, tierListContainer);
            PachinkoPassTierUI uiScript = tierUI.GetComponent<PachinkoPassTierUI>();
            uiScript.Setup(newTier);
        }
    }

    private string GetBallColorByTier(int tier)
    {
        switch (tier)
        {
            case 2: return "Red";
            case 4: return "Orange";
            case 6: return "Yellow";
            case 8: return "Green";
            case 10: return "Blue";
            case 12: return "Indigo";
            case 14: return "Violet";
            case 16: return "Gold";
            default: return "";
        }
    }
}

