using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameManager gameManager;
    public float speed = 10;
    private Rigidbody2D rb;
    private Animator anim;
    public Transform groundPos;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    public GameObject bloodEffect;

    public static bool isOver;

    void Start()
    {
        isOver = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        if(gameManager.isCanvasOn == false)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (moveInput < 0 && gameManager.isCanvasOn == false)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

        }
        else if (moveInput > 0 && gameManager.isCanvasOn == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bug")
        {
            isOver = true;
            Audio.getAttackSoundPlay();
            gameManager.gameOver();
            GameObject effect = Instantiate(bloodEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            anim.SetTrigger("Die");
            Destroy(this.gameObject);
        }
    }

}
