using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private HealthHandler playerHealth;

    public void UpdateBar()
    {
        healthBar.fillAmount = (float)playerHealth.CurHealth / playerHealth.MaxHealth;
    }
}
