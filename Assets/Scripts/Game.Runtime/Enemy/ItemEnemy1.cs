using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEnemy1 : MonoBehaviour
{
    public HealthEnemy enemy;
    public Transform enemyLocal;
    public GameObject itemDrop;
    private bool on;// - update item ìninity 
// using nhan ban? prefap de random ra nhieu item
    void Update()
    {
        if (enemy.currentHealth == 0& !on)
        {
            itemDrop.transform.position = new Vector3(enemyLocal.position.x, enemyLocal.position.y+0.5f, enemyLocal.position.z);
            itemDrop.SetActive(true);
            on = true;
        }
    }
}
