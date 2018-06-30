using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class playButton : MonoBehaviour {

    public RawImage image;
    public Sprite[] playButt;
    public VideoPlayer vidPlayer;
    private bool turn;
    private Image curImage;
    private float repeat = 2f;
    public Text loadingMssg;
    public videoWaitMessage videoScript;


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
                curImage.sprite = playButt[1];
            else
                curImage.sprite = playButt[0];
            repeat = 2f;
        }
        if (vidPlayer.isPlaying)
        {
            loadingMssg.enabled = false;
            gameObject.SetActive(false);
        }
            
        
    }
    /*
    public void OnMouseDown()
    {
        image.enabled=true;
        loadingMssg.enabled = true;
        videoScript.playVid();
        //vidPlayer.Play();
        
    }*/
}
