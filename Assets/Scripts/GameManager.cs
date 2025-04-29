using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    public float spawnCooldown = 1f; // Time (in seconds) between ball spawns
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
        int savedMoney, savedScore;
        string equippedBall;
        SaveManager.LoadProgress(out savedMoney, out savedScore, out equippedBall);

        money = savedMoney;
        score = savedScore;

        BallManager.instance.EquipBallByName(equippedBall); // You'll implement this in BallManager

        UpdateUI();
    }



    void Update()
    {
        if (GameManager.shopIsOpen) return;
        {
            if (Input.GetMouseButtonDown(0) && Time.time >= lastSpawnTime + spawnCooldown)
            {
                TryDropBall();
                lastSpawnTime = Time.time;
            }
        }

    }

    void TryDropBall()
    {
        if (money >= 1)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos = new Vector3(worldPos.x, ballSpawnHeight.position.y, 0);

            // Use equipped ball if available
            GameObject prefabToSpawn = BallManager.instance.currentBall != null
                ? BallManager.instance.currentBall.prefab
                : ballPrefab;

            Instantiate(prefabToSpawn, worldPos, Quaternion.identity);
            money -= 1;
            SaveManager.SaveProgress(money, score, BallManager.instance.currentBall.ballName);
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
        SaveManager.SaveProgress(money, score, BallManager.instance.currentBall.ballName);
        UpdateUI();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        SaveManager.SaveProgress(money, score, BallManager.instance.currentBall.ballName);
        UpdateUI();
    }


    public void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        moneyText.text = "Money: $" + money;
    }

}


