using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;

    public PlayerScript PlayerScript;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        PlayerScript = PlayerScript.GetComponent<PlayerScript>();
    }

    
    void Update()
    {
        if (PlayerScript.startTimer)
        {
            waitTime -= Time.deltaTime;
        }
        if (!PlayerScript.startTimer)
        {
            waitTime = 3;
        }
        
        if(waitTime <= 0)
        {
            effector.rotationalOffset = 180f;
            waitTime = 3;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            effector.rotationalOffset = 0f;
        }

        if(waitTime > 0 && waitTime < 2.6f)
        {
            effector.rotationalOffset = 0f;
        }
    }
}
