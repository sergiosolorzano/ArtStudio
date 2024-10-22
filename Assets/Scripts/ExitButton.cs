﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class ExitButton: MonoBehaviour {
    public Sprite[] exitButton;
    public VideoPlayer vidPlayer;
    private bool turn;
    private Image curImage;
    private float repeat = 2f;
    public Text loadingMssg;


    void Start ()
    {
        curImage = transform.GetComponent<Image>();
	}

    public void FullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    void Update()
    {
        repeat -= Time.deltaTime;

        if (repeat < 0)
        {
            turn = !turn;
            if (turn)
                curImage.sprite = exitButton[1];
            else
                curImage.sprite = exitButton[0];
            repeat = 2f;
        }
    } 

    IEnumerator ChangeScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("StudioScene");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void OnMouseDown()
    {
            loadingMssg.enabled = true;
            vidPlayer.Pause();
            FullScreen();
            Cursor.lockState = CursorLockMode.Locked;
            StartCoroutine(ChangeScene());
    }
}








    /*
        if (Input.GetKeyDown("escape"))
        {
            loadingMssg.enabled = true;
            StartCoroutine(ChangeScene());
        }*/



/*private void OnMouseDown()
{

    loadingMssg.enabled = true;
    vidPlayer.Pause();
    FullScreen();
    Cursor.lockState = CursorLockMode.Locked;
    StartCoroutine(ChangeScene());
}*/
