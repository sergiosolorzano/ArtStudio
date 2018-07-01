using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MouseTarget : MonoBehaviour {
    public Texture2D mouseTarget;
    public Texture2D [] mouseTargetArray;
    public bool useMouseCursorToRecord;
    
    private CursorMode curMode;
    private Vector2 hotSpot;
    private Vector2 mouse;

    void Start ()
    {
        if(!useMouseCursorToRecord)
        {
            curMode = CursorMode.Auto;
            hotSpot = new Vector2(mouseTarget.width * 0.5f, mouseTarget.height * 0.5f);
            Cursor.SetCursor(mouseTarget, hotSpot, curMode);
        }
        else
        {
            curMode = CursorMode.ForceSoftware;
            hotSpot = Vector2.zero;
        }
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if(useMouseCursorToRecord)
        {
            Debug.Log("Mouse Y " + Input.GetAxis("Mouse Y") + " Mouse X " + Input.GetAxis("Mouse X"));

            if (Input.GetAxis("Mouse Y") > 0.7)
                mouseTarget = mouseTargetArray[0];
            if (Input.GetAxis("Mouse Y") < -0.7)
                mouseTarget = mouseTargetArray[1];
            if (Input.GetAxis("Mouse X") > 0.7)
                mouseTarget = mouseTargetArray[2];
            if (Input.GetAxis("Mouse X") < -0.7)
                mouseTarget = mouseTargetArray[3];

            if (Input.GetKey("up") && Input.GetAxis("Mouse X") == 0)
                mouseTarget = mouseTargetArray[4];
            if (Input.GetKey("down"))
                mouseTarget = mouseTargetArray[5];
            if (Input.GetKey("right"))
                mouseTarget = mouseTargetArray[6];
            if (Input.GetKey("left"))
                mouseTarget = mouseTargetArray[7];

            if (Input.GetKey("up") && Input.GetAxis("Mouse X") > 0.7)
                mouseTarget = mouseTargetArray[8];
            if (Input.GetKey("up") && Input.GetAxis("Mouse X") < -0.7)
                mouseTarget = mouseTargetArray[9];

            mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        }
    }

    private void OnGUI()
    {
        if(useMouseCursorToRecord)
            GUI.DrawTexture(new Rect(mouse.x - (mouseTarget.width / 2), mouse.y - (mouseTarget.height / 2), mouseTarget.width, mouseTarget.height), mouseTarget);
    }
}
