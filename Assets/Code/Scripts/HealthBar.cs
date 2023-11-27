using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangeMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void ChangeCurrentHealth(int healthAmmount)
    {
        slider.value = healthAmmount;
    }

    public void InitializeHealthBar(int healthAmmount)
    {
        ChangeMaxHealth(healthAmmount);
        ChangeCurrentHealth(healthAmmount);
    }
}