using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    //gjord av Simon
    private void OnTriggerEnter2D(Collider2D collision) //när man nuddar ett specifikt block så byter man till nästa scen (slutet)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
