using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private HealthHandler health;

    public void UpdateBar()
    {
        healthBar.fillAmount = (float)health.CurHealth / health.MaxHealth;
    }
}
