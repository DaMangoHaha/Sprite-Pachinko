using UnityEngine;

public static class SaveManager
{
    public static void SaveProgress(int money, int score, string equippedBall)
    {
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetString("EquippedBall", equippedBall);
        PlayerPrefs.Save();
    }

    public static void LoadProgress(out int money, out int score, out string equippedBall)
    {
        money = PlayerPrefs.GetInt("Money", 5); // Default starting value
        score = PlayerPrefs.GetInt("Score", 0);
        equippedBall = PlayerPrefs.GetString("EquippedBall", "Default");
    }

    public static void SaveUnlockedBall(string ballName)
    {
        PlayerPrefs.SetInt($"BallUnlocked_{ballName}", 1);
        PlayerPrefs.Save();
    }

    public static bool IsBallUnlocked(string ballName)
    {
        return PlayerPrefs.GetInt($"BallUnlocked_{ballName}", 0) == 1;
    }
}

