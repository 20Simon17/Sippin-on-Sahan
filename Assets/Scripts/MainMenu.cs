using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Gjord av Simon
public class MainMenu : MonoBehaviour
{
    
    public void PlayGame() //funktion man lägger i "start" knappen för att starta spelet
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
