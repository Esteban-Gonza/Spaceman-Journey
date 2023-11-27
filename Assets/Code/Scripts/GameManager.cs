using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int coinCount = 0;

    [Header("References")]
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

    public void AddCoins()
    {
        coinCount++;
        coinText.text = coinCount.ToString();
    }
}