using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperJump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    public float WingsForce = 30f;
    [SerializeField]
    public float WingsStrenght;
    public float WingsStrenghtLimit;
    public float SpeedLimit = 7;

    private bool isUsing;
    [SerializeField]
    private Slider UIBar;
    [SerializeField]
    KeyCode up;

    




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
          

      

        if (Input.GetKey(up))
        {
            if (WingsStrenght > 0)
            {
                StartWings();
               
            }
        }


        else
        {
            StopWings();
        }
        if (WingsStrenght <= 0 && isUsing == false)
        {
            StopWings();
        }
        
        
    }
    void StartWings()
    {
        if (rb.velocity.y < SpeedLimit)
        {
            rb.AddForce(Vector3.up * WingsForce);
        }
        
        WingsStrenght -= Time.deltaTime;
        isUsing = true;
        StaminaBar.instance.UseStamina(1);
    }
    void StopWings()
    {
        if (WingsStrenght < WingsStrenghtLimit)
        {
            WingsStrenght += Time.deltaTime;
        }
        
        isUsing = false;;
    }
        
}