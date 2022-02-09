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
        //Skriven av Elliot
        //Den här gör så att om spriten tittar vänster kommer den att flippa sig till vänster sida och göra samma på andra sidan
        float horiz = Input.GetAxis("Horizontal");
        if(horiz < 0)
        {
            sprite.flipX = true;
        }
        else if(horiz > 0)
        {
            sprite.flipX = false;
        }

        
        #region PlatformCheck
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 5f, mask);
        Debug.DrawRay(transform.position, -transform.up, Color.black, 5f);*/

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size - new Vector3(0.1f,0,0), 0, -transform.up, 0.1f, mask);

        if (hit.transform != null)
        {
            startTimer = true;
            isGrounded = true;  
        }
        else
        {
            startTimer = false;
            isGrounded = false;
        }

        #endregion

        #region Movement
        float horizontalMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);

        #endregion

        #region Jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(transform.up * jumpPower);
        }
        #endregion


        //skriven av Elliot
        //Den här gör så att om animatorn står still om inte kommer den att spela spring animatorn.
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
    }
}
