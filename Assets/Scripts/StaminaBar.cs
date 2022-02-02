using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    private int maxStamina = 100;
    public float currentStamina;

    public static StaminaBar instance;
    
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public SuperJump player;

    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    // Update is called once per frame
    private void Update()
    {
        staminaBar.value = currentStamina;
        
     /*   if (currentStamina > 10)
        {
          //  player.WingsForce = 30f;
            if (Input.GetKey(KeyCode.W))
            {
                UseStamina(75f);
            }
            //player.WingsStrenght = 10f;
        }
        else if (currentStamina <= 40)
        {
           
          //  player.WingsForce = 10f;
        }*/
      
    }
    public void UseStamina(float amount)
    {
        currentStamina -= amount;

        if (currentStamina - amount>=0)
      {
            
            staminaBar.value = currentStamina;

            if (regen != null)
            {
                StopCoroutine(regen);
            }

           regen =  StartCoroutine(RegenStamina());
      }
       else
       {
            Debug.Log("Not Enough Stamina");
           
       }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina )
        {
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }
}
