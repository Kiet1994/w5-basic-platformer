using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthColection : MonoBehaviour
{
    public float healthValue;
    public GameObject enemy;
    private void OnTriggerEnter2D(Collider2D a)
    {
        if (a.tag == "Player")
        {
            a.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false); 
        }
    }
    private void Update()
    {
        transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y +1);
    }
}
