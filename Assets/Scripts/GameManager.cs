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
        UpdateUI();

    }


    void Update()
    {
        if (GameManager.shopIsOpen) return;

        if (Input.GetMouseButtonDown(0))
        {
            TryDropBall();
        }
    }

    void TryDropBall()
    {
        if (money >= 1)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos = new Vector3(worldPos.x, ballSpawnHeight.position.y, 0);

            Instantiate(ballPrefab, worldPos, Quaternion.identity);
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


