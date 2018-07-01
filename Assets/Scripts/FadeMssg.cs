using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class FadeMssg : MonoBehaviour, IPointerDownHandler {
    private bool fade=true;
    public Text clickMssg;

    public void Update()
    {
        Debug.Log("fade " + fade);
        if (fade)
        {
            clickMssg.CrossFadeAlpha(0, 4.0f, false);
        }
        else
        {
            clickMssg.CrossFadeAlpha(0, 0.0f, false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Cursor.lockState = CursorLockMode.Locked;
        fade = false;
    }
}
