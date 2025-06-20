using UnityEngine;
using TMPro; // for updating UI text

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int level = 1;
    public int currentEXP = 0;
    public int expToNextLevel = 25;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI expText;

    void Awake()
    {
        // Singleton pattern to ensure one instance of LevelManager
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

    void Start()
    {
        UpdateUI();
    }

    // Add EXP and handle leveling up
    public void AddEXP(int amount)
    {
        currentEXP += amount;

        // Check if we need to level up
        if (currentEXP >= expToNextLevel)
        {
            LevelUp();
        }

        UpdateUI();
    }

    // Handle leveling up
    private void LevelUp()
    {
        level++;
        currentEXP -= expToNextLevel; // Subtract the EXP needed for the next level

        // Increase the EXP required for the next level (by 25 each time)
        expToNextLevel += 25;
    }

    // Update UI elements to show current level and EXP
    private void UpdateUI()
    {
        levelText.text = "Level: " + level;
        expText.text = "EXP: " + currentEXP + "/" + expToNextLevel;
    }
}


