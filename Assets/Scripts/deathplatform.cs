using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Skriven av Elliot
public class deathplatform : MonoBehaviour
{
    [SerializeField]
    Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    //Den här gör så att om "DeathPlatform" rör vid playern kommer den ta playern till en specifik plats som sätts i unity
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            //collision.transform.position = destination.position;
            PlayerScript.hasKey = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}