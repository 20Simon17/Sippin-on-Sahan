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
    //Den h�r g�r s� att n�r man b�rjar kommer man ha full stamina
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
    //Den h�r g�r s� att om man anv�nder "stamina" s� kollar den om man har tillr�ckligt och om man har s� kommer den starta k�ra sin "flyg speed" om inte kommer han l�ngsamt att f� tillbaka sitt stamina
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
    //Den har g�r s� att om man inte anv�nder stamina kommer den v�nta i 2 sekunder f�r att sedan b�rja sin regen med att ge tillbaka stamina varje tick
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina )
        {
            currentStamina += maxStamina / 50;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }
    #endregion
}
