using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumps : MonoBehaviour
{
    //gjord av Simon (skriptet)
    //detta skript är mer för att checka plattformarna så vi kan ta användning av platformeffector 2d än för att hoppa -Simon

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
        //skapar en boxcast i formen av spelarens boxcollider, men lite under spelaren för att checka om spelaren är på marken eller ej. den är lite kortare på höger och vänster sida för att den inte ska bugga och detecta "ground" som vägg. -Simon

        if (hit.transform != null) //om boxcasten träffar någonting så startas timern för plattformarna och man är "isgrounded" vilket betyder att man kan hoppa igen -Simon
        {
            startTimer = true;
            isGrounded = true;
        }
        else //om den inte träffar något så stängs timern av och man är inte grounded = inga hopp. -Simon
        {
            startTimer = false;
            isGrounded = false;
        }

        #endregion

        #region Jump
        if (isGrounded && Input.GetButtonDown("Jump")) //om man är på marken och trycker på "Jump" knappen vilket defaultar till spacebar, så hoppar man -Simon
        {
            rb.AddForce(transform.up * jumpPower);
            FindObjectOfType<AudioManeger>().Play("PlayerJump"); //när man hoppar så spelas hoppljudet upp -Theo
        }
        #endregion

        



    }

}

