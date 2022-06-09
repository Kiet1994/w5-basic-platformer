using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [Header("Health")]// chú thích ? ph?n Inpector
    [SerializeField] private float startingHealth; //hp start
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;


    [Header("iFrames")] //?
    [SerializeField] private float iFramesDuration; // th?i gian b?t t?
    [SerializeField] private int numberOfFlashes; // th?i gian nhân v?t màu ??
    private SpriteRenderer spriteRend; // Color When Be Hit

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>(); //?

    }
    public void TakeDamage(float _damage) // Nh?n  sát th??ng
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth); // 
        Debug.Log(currentHealth);
        if (currentHealth > 0)
        {
            // anim.SetTrigger("hurt");
            StartCoroutine(Invunerability()); //Th?c hi?n câu l?nh Invunerability ? d??i
        }
        else
        {
            //if (!dead)  // 
            //{
            // anim.SetTrigger("die");
            //GetComponent<PlayerMovement>().enabled = false; // player không di chuy?n khi ch?t.  
            // GetComponent<PlayerAttack>().enabled = false;
            //dead = true;
            // }
            gameObject.SetActive(false);
        }
        //Debug.Log(currentHealth);
    }
    private IEnumerator Invunerability() // B? th??ng ??i màu ??ng th?i b?t t? trong th?i gian ?ó
    {
        Physics2D.IgnoreLayerCollision(10, 11, true); // b? qua va ch?m gi?a 2 l?p 10, 11 (player and enemy)
        for (int i = 0; i < numberOfFlashes; i++) // l?p i = 0, i s? nguyên nên l?p l?i 1 l?n n?u numberOfFlashes là 1
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f); //??i màu ??
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2)); // th?i gian duy trì 1s
            spriteRend.color = Color.white; //??i màu tr?ng
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2)); // th?i gian duy trì 1s
        }
        //invunerabity du?tion
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
