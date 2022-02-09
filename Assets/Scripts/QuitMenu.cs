using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitMenu : MonoBehaviour
{
     //gjord av Simon
    public void YesQuit() //funktion för att avsluta spelet när man trycker på quit knappen i menyn
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
