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
    public bool isUIOverride { get; private set; }

    public void Update()
    {
        if (fade)
        {
            clickMssg.CrossFadeAlpha(0, 6.0f, false);
            Debug.Log("fading on");
        }
        else
        {
            clickMssg.CrossFadeAlpha(0, 0.0f, false);
            Debug.Log("fading off");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Inside Pointer");
        fade = false;
    }
}
