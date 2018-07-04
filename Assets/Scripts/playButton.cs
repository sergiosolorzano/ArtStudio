using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class playButton : MonoBehaviour, IPointerClickHandler {

    public Sprite[] playButt;
    private bool turn;
    private Image curImage;
    private float repeat = 2f;
    public VideoPlayer vidPlayer;
    private videoWaitMessage videoScript;

    void Start()
    {
        curImage = transform.GetComponent<Image>();
        videoScript = vidPlayer.GetComponent<videoWaitMessage>();
    }

    void Update()
    {
        repeat -= Time.deltaTime;

        if (repeat < 0)
        {
            turn = !turn;
            if (turn)
                curImage.sprite = playButt[0];
            else
                curImage.sprite = playButt[1];
            repeat = 2f;
        }
        /*if (vidPlayer.isPlaying)
        {
            loadingMssg.enabled = false;
            gameObject.SetActive(false);
        }*/
            
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        curImage.enabled = false;
        Screen.fullScreen = true;
        videoScript.enabled = true;
        gameObject.SetActive(false);
    }
}
