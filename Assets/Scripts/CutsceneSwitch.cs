using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Gjord av Simon
public class CutsceneSwitch : MonoBehaviour
{

    public void NextCutscene() //knapp för att byta till nästa scen i cutscenes
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SkipCutscene() //knapp för att hoppa över cutscene och börja spela
    {
        SceneManager.LoadScene("Sahan Platform");
    }

    public void SkipEndCutscene() //knapp för att hoppa över sista cutscenen
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void BackToMenu() //knapp för att komma tillbaka till menyn
    {
        SceneManager.LoadScene(0);
    }

}