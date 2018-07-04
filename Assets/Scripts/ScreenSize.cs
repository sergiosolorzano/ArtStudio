using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour {

    int defScreenWidth, defScreenHeight;

    // Use this for initialization
    void Start () {
        
    }

    public void ScrnWidth(int scrnWidth)
    {
        defScreenWidth = scrnWidth;
        Debug.Log("Unity has set defScWidth to " + defScreenWidth);
    }

    public void ScrnHeigth(int scrnHeigth)
    {
        defScreenWidth = scrnHeigth;
        Debug.Log("Unity has set defScHeigth to " + defScreenHeight);
    }

    public void ControlLargeScreenSize()
    {
        Screen.SetResolution(defScreenWidth, defScreenHeight, false);
        Debug.Log("Unity has set resolution to width " + defScreenWidth + " heigth " + defScreenHeight);
    }

}
