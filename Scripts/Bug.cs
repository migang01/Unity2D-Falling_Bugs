using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    private Animator anim;
    private float speed = 5;
    public GameObject bloodEffect;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
         transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Audio.KillBugSoundPlay();
            anim.SetTrigger("Die");
            GameObject effect = Instantiate(bloodEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);

            if(PlayerMovement.isOver == false)
            {
                Score.score++;
            }         

            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "MainCamera")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Audio.KillBugSoundPlay();
            anim.SetTrigger("Die");
            GameObject effect = Instantiate(bloodEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(this.gameObject);
        }
    }
}

