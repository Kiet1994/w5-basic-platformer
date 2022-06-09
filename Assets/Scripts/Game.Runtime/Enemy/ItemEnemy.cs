using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEnemy : MonoBehaviour
{
    public HealthEnemy enemy;
    public GameObject health;
    private bool on;
// using nhan ban? prefap de random ra nhieu item
    void Update()
    {
        if (enemy.currentHealth == 0& !on)
        {
            health.SetActive(true);
            on = true;
        }
    }
}
