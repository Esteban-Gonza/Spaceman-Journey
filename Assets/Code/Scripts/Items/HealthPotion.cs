using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    public override void Activate()
    {
        GameManager.Instance.IncreaseHealth();
        gameObject.SetActive(false);
    }
}