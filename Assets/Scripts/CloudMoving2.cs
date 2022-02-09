using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Skriven av Elliot
public class CloudMoving2 : MonoBehaviour
{
    [SerializeField, Range(1, 10)]
    float speed;
    Vector3 direction = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //Den här gör så att molnet rör sig åt Höger med specifik hastighet
    void Update()
    {
        transform.position += speed * direction * Time.deltaTime;
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }
}
