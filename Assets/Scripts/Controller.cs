using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator anim;
    private bool moved;
    private bool landed;

  //  public Animation animation;



    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moved = false;
        landed = false;
        rigidbody.gravityScale = 1;
    }

    private void OnEnable()
    {
        moved = false;
        landed = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isHolding && !moved)
        {
           
            Vector3 mousepos;
            mousepos = Input.mousePosition;
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);
            mousepos.x = Mathf.Clamp(mousepos.x, -2, 2);

            transform.localPosition = new Vector3(mousepos.x, mousepos.y, 0);


        }
        if(PlayerController.isdead)
        {
            PlayDead();
        }
       
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !moved)
        {
            PlayerController.isHolding = true;
            //  rigidbody.gravityScale = 0;
            rigidbody.bodyType = RigidbodyType2D.Kinematic;

        }
    }
    private void OnMouseUp()
    {
        if (!moved)
        {
            PlayerController.isHolding = false;
            //  rigidbody.gravityScale = 1;
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
           
        }
        if(PlayerController.isdead)
        {
            rigidbody.bodyType = RigidbodyType2D.Kinematic;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("blocks") || collision.gameObject.CompareTag("stick"))
        {
            
            moved = true;
          
            PlayerController.isHolding = false;
            PlayerController.isPlaced = true;

           StartCoroutine(PlayLanded(collision.contacts[0].normal));

            PlayerController.instance.DidCompleted();
           // StartCoroutine(PlayLanded());
           // StartCoroutine(freeze());
        }
        //if(collision.gameObject.CompareTag("dead"))
        //{
        //    PlayerController.isdead = true;
        //    PlayerController.instance.Gameover.SetActive(true);
        //}

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("dead"))
        {
            PlayerController.isdead = true;
           
            Vector3 vector = col.ClosestPoint(transform.position);

            ParticleSys.instance.UpgradeFx(vector);
            StartCoroutine(GameOver());
        }
    }



    IEnumerator freeze()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        rigidbody.constraints = RigidbodyConstraints2D.None;
        rigidbody.bodyType = RigidbodyType2D.Dynamic;


        yield return new WaitForSeconds(1f);
      //  rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;

    }

    //IEnumerator PlayLanded()
    //{
    //    yield return new WaitForSeconds(3f);
    //    //  anim.SetBool("landed", true);


    //    float Animlength = animation.clip.length; //gets the clip length
    //    Animlength = (Animlength - 10); //takes 10 sec away
    //    float Frame = Random.Range(10f, Animlength); //random chooses a time
    //    animation.Play(); //plays the animation clip on character
    //   // animation.normalizedTime = Frame; //starts anim at that time
    //    //animation.speed = WhatSpeed;

    //}

    public void PlayDead()
    {
       
        anim.SetBool("isdead", true);
    }

    public void clampPos()
    {
        var pos = transform.localPosition;
        pos.x = Mathf.Clamp(transform.localPosition.x, -2.0f, 2.0f);
        transform.position = pos;
    }

    IEnumerator PlayLanded(Vector3 vec)
    {
        if(landed==false)
        {
            ParticleSys.instance.CollectParticles(vec);

        }
        landed = true;
        
        yield return new WaitForSeconds(3f);
        landed = false;
        
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1f);
        UI_Manager.instance.ActivatePage(3);
    }
}
