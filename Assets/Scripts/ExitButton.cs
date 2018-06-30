using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class ExitButton: MonoBehaviour,IPointerDownHandler {
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

    public void OnPointerDown(PointerEventData eventData)
    {
        loadingMssg.enabled = true;
        vidPlayer.Pause();
        Screen.fullScreen=true;
        //Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(ChangeScene());
    }
}