using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MinScreen : MonoBehaviour, IPointerDownHandler  {
    public Sprite[] exitButt;
    private Image curImage;
    private bool exitButtType;

    public void OnPointerDown(PointerEventData eventData)
    {
        Screen.fullScreen = !Screen.fullScreen;
        curImage.sprite = exitButt[Convert.ToInt32(exitButtType)];
        exitButtType = !exitButtType;
    }

    void Start ()
    {
        curImage = GetComponent<Image>();
    }
	
	void Update () {
		
	}
}
