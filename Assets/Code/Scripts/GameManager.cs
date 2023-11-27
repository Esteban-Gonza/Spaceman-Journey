using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int coinCount = 0;
    public int playerHealth;
    public int playerMaxHealth;

    [Header("References")]
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private PlayerController player;
    public TextMeshProUGUI coinText;

    public int CoinCount => coinCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerHealth = playerMaxHealth;
        healthBar.InitializeHealthBar(playerHealth);
    }

    private void Update()
    {
        if(playerHealth <= 0)
        {
            player.Death();
        }
    }

    public void AddCoins()
    {
        coinCount++;
        coinText.text = coinCount.ToString();
    }

    public void IncreaseHealth()
    {
        playerHealth++;
        healthBar.ChangeCurrentHealth(playerHealth);
    }
}