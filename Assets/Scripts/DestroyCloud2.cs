using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CloudMoving2")
        {
            collision.transform.position = destination.position - new Vector3(Random.Range(-2, 2), Random.Range(10, 50), 0);
        }

    }
}
