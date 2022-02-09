using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Gjord av Simon
public class PauseMenu : MonoBehaviour
{ //variabler
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //om man trycker på escape...
        {
            if (GameIsPaused) //... och spelet är pausat, då startas det igen
            {
                Resume();
            }
            else //... och spelet körs, då pausas det
            {
                Pause();
            }
        }
    }
    public void Resume() //återuppta spelet funktionen
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() //paus funktionen
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu() //funktion för att gå tillbaka till start menyn
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
