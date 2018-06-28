using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour {
    public Sprite[] exitButton;
    private bool turn;
    private Image curImage;
    private float repeat = 2f;


    void Start ()
    {
        curImage = transform.GetComponent<Image>();
	}

	void Update ()
    {
        repeat -= Time.deltaTime;

        if(repeat<0)
        {
            turn = !turn;
            if (turn)
                curImage.sprite = exitButton[1];
            else
                curImage.sprite = exitButton[0];
            repeat = 2f;
        }
    }
}
