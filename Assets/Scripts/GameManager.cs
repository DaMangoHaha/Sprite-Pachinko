using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool shopIsOpen = false;

    public int score = 0;
    public int money = 5;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI moneyText;

    public GameObject ballPrefab;
    public Transform ballSpawnHeight;
    public float spawnCooldown = 1f;
    private float lastSpawnTime = -999f;

    void Awake()
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

    void Start()
    {
        score = 0;
        money = 5;
        UpdateUI();
    }

    void Update()
    {
        if (shopIsOpen) return;

        if (Input.GetMouseButtonDown(0) && Time.time >= lastSpawnTime + spawnCooldown)
        {
            TryDropBall();
            lastSpawnTime = Time.time;
        }
    }

    void TryDropBall()
    {
        if (money >= 1)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos = new Vector3(worldPos.x, ballSpawnHeight.position.y, 0);

            GameObject prefabToSpawn = BallManager.instance.currentBall != null
                ? BallManager.instance.currentBall.prefab
                : ballPrefab;

            Instantiate(prefabToSpawn, worldPos, Quaternion.identity);
            money -= 1;
            UpdateUI();
        }
        else
        {
            Debug.Log("Not enough money to drop a ball!");
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateUI();
    }

    public void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        moneyText.text = "Money: $" + money;
    }
}


