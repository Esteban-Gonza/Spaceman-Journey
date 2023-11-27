using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public override void Activate()
    {
        GameManager.Instance.AddCoins();
        gameObject.SetActive(false);
    }
}
