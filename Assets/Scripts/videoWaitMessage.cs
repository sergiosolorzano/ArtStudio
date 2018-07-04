using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class videoWaitMessage : MonoBehaviour {
    public RawImage image;
    public Text vidLoadMssg;
    public Text pressStartMssg;
    public bool startMssgReady;
    public VideoClip videoToPlay;
    private VideoPlayer videoPlayer;
    private VideoSource videoSource;
    private bool fadeIn = true;

    
    //private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        Application.runInBackground = true;
        StartCoroutine(PlayVideo());
        image = GetComponent<RawImage>();
    }

    IEnumerator PlayVideo()
    {
        //Add VideoPlayer to the GameObject
        //videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer = GetComponent<VideoPlayer>();

        //Add AudioSource
        //audioSource = gameObject.AddComponent<AudioSource>();

        //Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = true;
        //audioSource.playOnAwake = false;
        //audioSource.Pause();

        //We want to play from video clip not from url

        //videoPlayer.source = VideoSource.VideoClip;

        // Vide clip from Url
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = "https://www.masfinance.co.uk/instructions.mp4";
        //videoPlayer.url = "https://www.youtube.com/watch?v=o5M3KJ8biU8";

        //Set Audio Output to AudioSource
        //videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        //Assign the Audio from Video to AudioSource to be played
        //videoPlayer.EnableAudioTrack(0, true);
        //videoPlayer.SetTargetAudioSource(0, audioSource);

        //Set video To Play then prepare Audio to prevent Buffering
        videoPlayer.clip = videoToPlay;
        videoPlayer.Prepare();
        vidLoadMssg.enabled = true;

        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        Debug.Log("Done Preparing Video");
        vidLoadMssg.enabled = false;

        //Assign the Texture from Video to RawImage to be displayed
        image.enabled = true;
        image.texture = videoPlayer.texture;

        //Play Video
        videoPlayer.Play();

        //Play Sound
        //audioSource.Play();

        while (videoPlayer.isPlaying)
        {
            yield return null;
        }
        Debug.Log("Done Playing Video");

        //Fade Message
        if ( (ulong)videoPlayer.frame==videoPlayer.frameCount)
        {
            pressStartMssg.enabled = true;

            if (fadeIn)
            {
                pressStartMssg.color = new Color(pressStartMssg.color.r, pressStartMssg.color.g, pressStartMssg.color.b, 0);
                StartCoroutine(FadeTextInOut(3, pressStartMssg));
            }
            else
            {
                pressStartMssg.color = new Color(pressStartMssg.color.r, pressStartMssg.color.g, pressStartMssg.color.b, 1);
                StartCoroutine(FadeTextInOut(3, pressStartMssg));
            }
        }
        else
            pressStartMssg.enabled = false;

    }

    public IEnumerator FadeTextInOut(float t, Text i)
    {
        while(true)
        {
            while (i.color.a < 1.0f)
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
                yield return null;
            }

            fadeIn = !fadeIn;

            while (i.color.a > 0.0f)
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
                yield return null;
            }

            fadeIn = !fadeIn;
        }
    }
    
}
