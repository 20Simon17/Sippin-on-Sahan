using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperJump : MonoBehaviour
{
    #region Variabler
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

    #endregion




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {



        #region WingsInput
        // Den här gör ås att om man trycker W kommer den kolla im man har tillräckligt med stamina för att flyga, om det är sant kommer den att start UseWings, om inte kommer man inte kunna använda vingarna 
        if (Input.GetKey(up))
        {
            if (isUsing == false && StaminaBar.instance.currentStamina > 10)
            {
                StaminaBar.instance.UseStamina(10);
                StartWings();
            }
           else if (StaminaBar.instance.currentStamina > 0 && isUsing)
            {
                StartWings();
               
            }
        }
        else
        {
            StopWings();
        }
        if (StaminaBar.instance.currentStamina <= 0 && isUsing == true)
        {
            StopWings();
        }
        #endregion

    }
    #region StartWings
    //Den här gör så att om man kunde använda vingarna kommer den att flyga upp lite med hjälp av stamina och den kommer använda stamina till den inte har tillräckligt
    void StartWings()
    {
        if (rb.velocity.y < SpeedLimit)
        {
            rb.AddForce(Vector3.up * WingsForce);
        }
        
   
        isUsing = true;
       StaminaBar.instance.UseStamina(25* Time.deltaTime);
    }
    #endregion 

    //Om man inte har tillräckligt med Stamina kommer den att bara simpelt att inte funka
    void StopWings()
    {
   
        
        isUsing = false;;
    }
        
}