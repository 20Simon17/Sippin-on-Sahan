using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField]
    public GameObject platformPathStart; //Referenser till Platform path start och Platform path end -Adam
    public GameObject platformPathEnd;
    public int speed; //fixar hastigheten som plattformen åker i -Adam
    private Vector3 startPosition; //Vector3 visar vart plattformen ska åka från point A till point B. -Adam
    private Vector3 endPosition;

    void Start()
    {
        startPosition = platformPathStart.transform.position;  //Visar vart plattformen ska starta och byta håll -Adam
        endPosition = platformPathEnd.transform.position;
        StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed)); //Fixar rörelsen till plattformen -Adam
    }
    void OnCollisionEnter(Collision col)  //När ett objekt kolliderar med plattformen så blir plattformen "parent" till objektet -Adam
    {
        if (col.transform.tag == "Player")
        {
            col.gameObject.transform.SetParent(gameObject.transform, true);
        }

    }
    void OnCollisionExit(Collision col) //När objektet slutar kollidera med plattformen så blir plattformen inte längre "parent" till det -Adam
    {
        print("hej då");
        col.gameObject.transform.parent = null;
    }


    void Update()
    {
        if (transform.position == endPosition) //Gör så att plattformen byter håll om den når PlatformPathEnd -Adam
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, startPosition, speed));
        }
        if (transform.position == startPosition)  //Gör så att plattformen byter håll om den når PlatformPathStart -Adam
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
        }
    }

    IEnumerator Vector3LerpCoroutine(GameObject obj, Vector3 target, float speed)
    {

        Vector3 startPosition = obj.transform.position;
        float time = 0f;

        while (obj.transform.position != target)
        {
            obj.transform.position = Vector3.Lerp(startPosition, target, (time / Vector3.Distance(startPosition, target)) * speed); //Fixar plattformens hastighet -Adam
            time += Time.deltaTime;
            yield return null;
        }
    }

}
