using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
//using System.Runtime.InteropServices;

public class ExtiScreenMessage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public Text mssg;
    public Text [] mssgType;
    public bool showEscOrMax;

    //[DllImport("__Internal")]
    //private static extern void LibraryFullScreen();

    // Use this for initialization
    void Start()
    {
        if (Screen.fullScreen == false)
        {
            ToSmallScrn();
        }
        else
        {
            ToFullScrn();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void ToFullScrn()
    {
        mssgType[0].enabled = true;
        Debug.Log("Box with full scrn");
    }
    public void ToSmallScrn()
    {
        mssgType[0].enabled = false;
        Debug.Log("Box off full scrn");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        mssg.color = new Color(mssg.color.r, mssg.color.g, mssg.color.b, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mssg.color = new Color(mssg.color.r, mssg.color.g, mssg.color.b, 0.5f);
    }
}
