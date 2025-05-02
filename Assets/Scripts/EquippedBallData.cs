using UnityEngine;

[System.Serializable]
public class EquippedBallData
{
    public string ballName;
    public GameObject prefab;
    public float moneyMultiplier = 1f;
    public float expMultiplier = 1f; // Optional, if you're using EXP
}

