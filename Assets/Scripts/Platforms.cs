using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Gjord av Simon
public class Platforms : MonoBehaviour
{ //variabler
    private PlatformEffector2D effector;
    public float waitTime;

    public PlayerScript PlayerScript;

    void Start()
    { //referenser till components
        effector = GetComponent<PlatformEffector2D>();
        PlayerScript = PlayerScript.GetComponent<PlayerScript>();
    }

    
    void Update()
    {
        if (PlayerScript.startTimer) //om "startTimer" är true, så startas timern här
        {
            waitTime -= Time.deltaTime;
        }
        if (!PlayerScript.startTimer) //om "startTimer" är false, så sätts timern till 3 sekunder
        {
            waitTime = 3;
        }
        
        if(waitTime <= 0) //om timern är mindre än 0 sekunder (du har stått på plattformen i 3 sekunder), då är platformeffectorn riktad neråt så du faller igenom plattformen
        {
            effector.rotationalOffset = 170f;
            waitTime = 3;
        }

        if (Input.GetKeyDown(KeyCode.Space)) //när man trycker på space så roteras platformeffectorn uppåt så du kan hoppa igenom plattformen underifrån
        {
            effector.rotationalOffset = 0f;
        }

        if(waitTime > 0 && waitTime < 2.6f) //om timern är över 0 men under 2,6 sekunder så är platformeffectorn riktad uppåt så du kan stå på den
        {
            effector.rotationalOffset = 0f;
        }
    }
}
