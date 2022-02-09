using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Skriven av Elliot
public class DestroyCloud : MonoBehaviour
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
    //Om ett object med taggern "CloudMoving" colliderar med objeckted d�r scripten �r p� kommer den att flyttas till specifik plats sat i unity p� random X linje.
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "CloudMoving")
        {
            collision.transform.position = destination.position + new Vector3(Random.Range(0,2),Random.Range(0,90),0);
        }
      

    }
}
