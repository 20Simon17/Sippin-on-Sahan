using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    #region Variables
    public bool startTimer;
    bool isGrounded;
    public LayerMask mask;

    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float jumpPower;

   
    private SpriteRenderer sprite;
    private Animator anim;
    public Animator animator;


    #endregion

    void Start()
    {
        #region References
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        #endregion
    }

    void Update()
    {
        //Gjord av Elliot

        #region SpriteRotation
        //Om spelaren rör sig mot ett speciellt håll kommer "spriten/gubben" att vända sin texture mot "rätt håll"
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

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size - new Vector3(0.1f,0,0), 0, -transform.up, 0.1f, mask); //skapar en boxcollider som är lite under spelaren och kan bara träffa plattformar

        if (hit.transform != null) //om boxcollidern träffar något så startas timern och isGrounded blir true
        {
            startTimer = true;
            isGrounded = true;  
        }
        else //om den inte träffar något så är startTimer false och isGrounded true
        {
            startTimer = false;
            isGrounded = false;
        }

        #endregion

        //Gjord av Simon
        #region Movement
        float horizontalMove = Input.GetAxis("Horizontal"); //hämtar höger och vänster input (fungerar med kontroll också)
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y); //använder höger och vänster inputen för att ändra gubbens velocity
        
        #endregion
        
        //Gjord av Simon
        #region Jump
        if (isGrounded && Input.GetButtonDown("Jump")) //om man är på marken och man trycker på "Jump" (space) så hoppar man
        {
            rb.AddForce(transform.up * jumpPower);
        }
        #endregion

        //Gjord av Elliot
        #region Animations
        //Om Spelaren rör sig, kommer "spring animationen" att köra igång tills spelaren inte rör sig.
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
}
