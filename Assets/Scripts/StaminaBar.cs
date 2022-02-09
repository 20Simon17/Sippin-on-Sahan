using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Skriven av Elliot
public class StaminaBar : MonoBehaviour
{


    #region Variabler 
    //Variabler som refererar till andra scripts och blir enklarare att skriva 
    public Slider staminaBar;
    private int maxStamina = 100;
    public float currentStamina;

    public static StaminaBar instance;
    
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public SuperJump player;

#endregion 

    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    #region Start
    //Den här gör så att när man börjar kommer man ha full stamina
    void Start()
    {

        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }
    #endregion

    // Update is called once per frame
    private void Update()
    {
        
       
        
   
      
    }
    #region UseStamina
    //Den här gör så att om man använder "stamina" så kollar den om man har tillräckligt och om man har så kommer den starta köra sin "flyg speed" om inte kommer han långsamt att få tillbaka sitt stamina
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
    #endregion

    #region RegenStamina
    //Den har gör så att om man inte använder stamina kommer den vänta i 2 sekunder för att sedan börja sin regen med att ge tillbaka stamina varje tick
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
    #endregion
}
