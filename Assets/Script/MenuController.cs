using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame(){
        Application.LoadLevel(1);
    }

    public void ExitGame(){
        Application.Quit();
    }

    void Update(){
        if (Input.GetKeyDown (KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
