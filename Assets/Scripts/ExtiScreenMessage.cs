using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ExtiScreenMessage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public Text mssg;
    public Text [] mssgType;
    public bool showEscOrMax;

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void SwitchMssg()
    {
        mssg.enabled = false;
        showEscOrMax = !showEscOrMax;
        mssg = mssgType[Convert.ToInt32(showEscOrMax)];
        mssg.enabled = true;
        Debug.Log("At switchMssg function in unity");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mssg.color = new Color(mssg.color.r, mssg.color.g, mssg.color.b, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mssg.color = new Color(mssg.color.r, mssg.color.g, mssg.color.b, 0.5f);
    }
    /*
    public void OnPointerUp(PointerEventData eventData)
    {
        if(showEscOrMax)
        {
            Screen.fullScreen = true;
            //Cursor.lockState = CursorLockMode.Locked;
            SwitchMssg();
        }
            
    }*/
}
