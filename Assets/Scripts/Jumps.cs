using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumps : MonoBehaviour
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

    #endregion



    // Start is called before the first frame update
    void Start()
    {
        #region References
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();

        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        #region PlatformCheck
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 5f, mask);
        Debug.DrawRay(transform.position, -transform.up, Color.black, 5f);*/

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size - new Vector3(0.1f, 0, 0), 0, -transform.up, 0.1f, mask);

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

        



    }

}

