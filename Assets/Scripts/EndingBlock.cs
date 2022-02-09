using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingBlock : MonoBehaviour
{
    void Update()
    {
        if (PlayerScript.hasKey) //om du har nyckeln, så försvinner väggen som blockerar slutet
        {
            gameObject.SetActive(false);
        }
    }
}
