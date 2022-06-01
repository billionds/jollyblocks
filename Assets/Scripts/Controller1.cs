using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller1 : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private AudioSource source;
    
    private Animator anim;
   
    public bool landed;
    public bool CanMove;
    private float _moveFactorX;
    private float _lastPositionX;
    private bool pressed;
    public float sensitivity;

    private bool hitOnce;
    

    //  public Animation animation;



    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        landed = false;
        CanMove = true;
       
    }

    private void OnEnable()
    {
      
       // landed = false;

    }

    private void Update()
    {

        if (landed == false)
        {

            if (Input.GetMouseButtonDown(0))
            {
                _lastPositionX = Input.mousePosition.x;
                pressed = true;
            }
            else if (Input.GetMouseButton(0))
            {
                _moveFactorX = Input.mousePosition.x - _lastPositionX;
                _lastPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _moveFactorX = 0f;
                pressed = false;
                rigidbody.gravityScale = 0.5f;

            }
            if (pressed)
            {
                Vector3 pos = new Vector3(Mathf.Clamp((transform.position.x + _moveFactorX * sensitivity * Time.deltaTime), -2, 2), transform.position.y - 0.01f, transform.position.z);
                rigidbody.gravityScale = 0f;

                transform.DOMove(pos, 0.1f).SetEase(Ease.Linear);

                Ui_Manager1.instance.Tutorials12();

            }
        }
        if(PlayerContoller1.instance.isDead)
        {
                anim.SetBool("isdead", true);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("blocks") || collision.gameObject.CompareTag("stick"))
        {
            if (!hitOnce)
            {
                PlayerContoller1.instance.CanPlace = true;
                hitOnce = true;
                PlayerContoller1.instance.DidCompleted();
                //Ui_Manager1.instance.Tutorials1();
                playsound();
            }
                StartCoroutine(PlayLanded(collision.contacts[0].normal));
                rigidbody.gravityScale = 1.0f;

           // playsound();

        }
    }
    IEnumerator PlayLanded(Vector3 vec)
    {
      
        if (landed == false)
        {
            ParticleSys.instance.CollectParticles(vec);

        }
        landed = true;
        yield return new WaitForEndOfFrame();
      //  PlayerContoller1.instance.check();
        
       // landed = false;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("dead"))
        {
           

            Vector3 vector = col.ClosestPoint(transform.position);
            PlayerContoller1.instance.Gamestarted = false;
            ParticleSys.instance.UpgradeFx(vector);
            // PlayerContoller1.instance.restart.SetActive(true);
            PlayerContoller1.instance.isDead = true;
            StartCoroutine(GameOver());
        }
    }

    public void playsound()
    {
        
        this.source.Play();
        
    }

    IEnumerator GameOver()
    {
        AudioManager.instance.onLevelFailed();
    
        yield return new WaitForSeconds(1f);
        Ui_Manager1.instance.ActivatePage(3);
      
    }

    public void PlayDead()
    {

        anim.SetBool("isdead", true);
    }
    public void Reset()
    {
        landed = false;
        hitOnce = false;
        transform.localPosition -= transform.position ;

    }
}
