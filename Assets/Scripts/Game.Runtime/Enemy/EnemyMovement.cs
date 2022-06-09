using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer; // n?i ?? layer cho player
    private bool move;
    private Vector3 destination; // l?u v? tr� c?a player ?? ?u?i theo
    private Vector3[] directions = new Vector3[4];


    private void Update()
    {
        if (move) // n?u true th�
            transform.Translate(destination * Time.deltaTime * speed);
        CheckForPlayer();    
        
    }
    private void CheckForPlayer()
    {
        CalculateDirections(); //g?i h�m CalculateDirections l�n d�ng
                               // ki?m tra n?u trap th?y player ? m?t trong 4 h??ng
       // for (int i = 0; i < directions.Length; i++)
      //  {
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + 1f), directions[1], Color.red); // v? tia chi?u c?a Raycast d?a tr�n v? tr�, h??ng, ph?m vi
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y +2f), directions[1], range, playerLayer); // chi?u tia 4 h??ng  
         
            if (hit.collider != null && !move) //chi?u tia 4 h??ng tia va ch?m phayer v? attacking ch?a b?t
            {
                move = true; // b?t l�n th?c hi?n h�m update di chuy?n trap ? tr�n
                destination = directions[1];                
            }
            else
            {
                move = false;
            }
        //}
    }

    private void CalculateDirections()
    {
       // directions[0] = transform.right * range;
        directions[1] = -transform.localScale.x * transform.right * range;
    }

  //  private void Stop()
   // {
   //     destination = transform.position;
   //     move = false;
 //   }

  //  private void OnTriggerEnter2D(Collider2D vacham)
    //{
     //   Stop();
  //  }
}
