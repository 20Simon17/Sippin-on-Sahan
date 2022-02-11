using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    #region Variables
    public bool startTimer; 
    bool isGrounded;
    public LayerMask mask;

    AudioManeger maneger;

    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float jumpPower;

   
    private SpriteRenderer sprite;
    private Animator anim;
    public Animator animator;

    public static bool hasKey = false;
    #endregion

    void Start()
    {
        #region References


        maneger = FindObjectOfType<AudioManeger>();
        rb = GetComponent<Rigidbody2D>(); //referens till spelarens rigidbody
        boxCollider2D = transform.GetComponent<BoxCollider2D>(); //referens till spelarens boxcollider2D
        sprite = GetComponent<SpriteRenderer>(); //referens till spelarens spriterenderer
        anim = GetComponent<Animator>(); //referens till spelarens animator
        #endregion
    }

    void Update()
    {
        //Gjord av Elliot

        #region SpriteRotation
        //Om spelaren r�r sig mot ett speciellt h�ll kommer "spriten/gubben" att v�nda sin texture mot "r�tt h�ll"
        float horiz = Input.GetAxis("Horizontal");
        if(horiz < 0)
        {
            sprite.flipX = true;
        }
        else if(horiz > 0)
        {
            sprite.flipX = false;
        }
        #endregion 
        
        //Gjord av Simon
        #region PlatformCheck
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 5f, mask);
        Debug.DrawRay(transform.position, -transform.up, Color.black, 5f);*/

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size - new Vector3(0.1f,0,0), 0, -transform.up, 0.1f, mask); //skapar en boxcollider som �r lite under spelaren och kan bara tr�ffa plattformar

        if (hit.transform != null) //om boxcollidern tr�ffar n�got s� startas timern och isGrounded blir true
        {
            startTimer = true;
            isGrounded = true;  
        }
        else //om den inte tr�ffar n�got s� �r startTimer false och isGrounded true
        {
            startTimer = false;
            isGrounded = false;
        }

        #endregion

        //Gjord av Simon
        #region Movement
        float horizontalMove = Input.GetAxis("Horizontal"); //h�mtar h�ger och v�nster input (fungerar med kontroll ocks�)
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y); //anv�nder h�ger och v�nster inputen f�r att �ndra gubbens velocity
        
        #endregion
        
        //Gjord av Simon
        #region Jump
        if (isGrounded && Input.GetButtonDown("Jump")) //om man �r p� marken och man trycker p� "Jump" (space) s� hoppar man
        {
            rb.AddForce(transform.up * jumpPower);
            maneger.Play("Player Jump");
        }
        #endregion

        //Gjord av Elliot
        #region Animations
        //Om Spelaren r�r sig, kommer "spring animationen" att k�ra ig�ng tills spelaren inte r�r sig.
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); 
        anim.SetBool("jump", !isGrounded);

        if(horizontalMove == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
        #endregion

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Gjord av Simon
        #region Key
        if (collision.tag == "Key") //om man kolliderar med nyckeln (trigger) s� blir "hasKey" true
        {
            hasKey = true;
            print("Got key!");
        }
        #endregion
    }
}
