using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float timeStop;
    [SerializeField] private float speed; // 

   // [SerializeField] private float PowerJump;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D body;
    private Animator anim;

    private BoxCollider2D boxCollider;

    private float move;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); //
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

        //walk
        move = Input.GetAxis("Horizontal"); // (-1,1)
        if (move != 0)
        {
            timeStop = 0;
            speed += Time.deltaTime;
            if (speed >= 3)
            {
                speed = 3f;
            }
        }
        else
        {
            timeStop += Time.deltaTime;
            if (timeStop >= 0.3f & move == 0)
            {
                speed = 1.5f;
            }
        }
        anim.SetFloat("speed", Mathf.Abs(move * 3 * speed));
        // xoay nguoi
        if (move > 0.01f) //n?u
            transform.localScale = Vector3.one;
        else if (move < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        //Debug.Log(speed);
        //Debug.Log(move);
        //move
        body.velocity = new Vector2(move * 2 * speed, body.velocity.y);
        //dk idle,run,walk
       // anim.SetBool("grounded", isGrounded());
        //jump
      //  if (Input.GetKeyDown(KeyCode.Space))
       //     Jump();

    }

    private bool isGrounded() //dieu kien idle, walk, run
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        // Chi?u 1 tia t? tâm boxcolilider xu?ng d??i v?i chi?u dài là 0,1 phát hi?n có ch?m vào groundLayer hay không.
        return raycastHit.collider != null; // n?u va ch?m thì th?c hi?n isGrounded()

    }
    ///private void Jump() //thi?t l?p Jump
   // {
      //  if (isGrounded())
      //  {
     //       body.velocity = new Vector2(body.velocity.x, PowerJump);
    //        anim.SetTrigger("jump");
    //    }
   // }
}