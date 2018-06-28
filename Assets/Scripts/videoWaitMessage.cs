using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoWaitMessage : MonoBehaviour {
    private VideoPlayer vidPlayer;

	void Start () {
        vidPlayer = GetComponent<VideoPlayer>();
        StartCoroutine(playVid());
	}
	
    IEnumerator playVid()
    {
        while (!vidPlayer.isPrepared)
        {
            Debug.Log("Preparing Video");
            yield return null;
        }

        Debug.Log("Done Preparing Video");

        while (vidPlayer.isPlaying)
        {
            yield return null;
        }
        Debug.Log("Done Playing Video");
    }

	void Update ()
    {
        

    }
}
