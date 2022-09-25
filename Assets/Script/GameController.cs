using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text winText;
    public Text failtext;
    // Start is called before the first frame update
    void Start()
    {
        failtext.text = "";
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(failtext.text == "Fail!!!" || winText.text == "Win!!!"){
            if (Input.GetKeyDown (KeyCode.S))
            {
                Application.LoadLevel (Application.loadedLevel);
            }
        }

        if (Input.GetKeyDown (KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }
    }
}
