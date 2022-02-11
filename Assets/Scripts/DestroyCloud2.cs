using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Skriven av Elliot
public class DestroyCloud2 : MonoBehaviour
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
    //Om ett object med taggern "CloudMoving2" colliderar med objeckted där scripten är på kommer den att flyttas till specifik plats sat i unity på random X linje.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CloudMoving2")
        {
            collision.transform.position = destination.position - new Vector3(Random.Range(0, 2), Random.Range(0, 50), 0);
        }

    }
}
