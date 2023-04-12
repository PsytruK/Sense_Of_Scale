using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class BlockResizer : MonoBehaviour
{
    public GameObject rCube;

    public Vector3 scaleChange, positionChange;

    public Button XP, XM, YP, YM, ZP, ZM, rst;

    public TMP_Text xDim, yDim, zDim;

    public LineRenderer Line;

    //floats to store the initial position, size, and adjsuted size of the cube
    public float X, Y, Z, initLocX, initLocY, initLocZ, sizeX, sizeY, sizeZ;


    // Start is called before the first frame update
    void Start()
    {
        //Initialize initial position
        initLocX = rCube.transform.position.x;
        initLocY = rCube.transform.position.y;
        initLocZ = rCube.transform.position.z;

        //Save initial size
        sizeX = rCube.transform.localScale.x;
        sizeY = rCube.transform.localScale.y;
        sizeZ = rCube.transform.localScale.z;

        //Initialize initial size
        X = sizeX;
        Y = sizeY;
        Z = sizeZ;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Every frame, check to make sure that the Cube is still attached to the floor
        //The cubes position is measured from the center of the object, akin to radius, so if the Y position of the object isn't half of the Y Size, it is clipping
        //Could have made this its own function, decided to leave here since I do not need to call multiple times.
        if(rCube.transform.position.y != (ToFloat(1/2))*(sizeY))
        {
            //Move the position of Y to equal half of the Y scale, but leave the X and Z according to initial sizing.
            rCube.transform.position = new Vector3(initLocX, (0.5f)*(sizeY), initLocZ);
        }
        

        //Text for displaying current cube value
        xDim.text = "X: " + X.ToString() +"m";
        yDim.text = "Y: " + Y.ToString() +"m";
        zDim.text = "Z: " + Z.ToString() +"m";

        //Code from Assignment 3 for the Physics raycast
        Line.SetPosition(0, transform.position);

        Line.SetPosition(1, transform.position + (transform.forward * 20));
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit);


        if (hit.collider)
        {
            //Using switch statement felt more efficient than an if/else, especially with this many buttons.
            switch (hit.collider.tag)
            {
                case "XP":
                    XP.Select();
                    break;

                case "XM":
                    XM.Select();
                    break;

                case "YP":
                    YP.Select();
                    break;

                case "YM":
                    YM.Select();
                    break;

                case "ZP":
                    ZP.Select();
                    break;

                case "ZM":
                    ZM.Select();
                    break;

                case "rst":
                    rst.Select();
                    break;
            }
        }
        //If no button hit
        else
        {
            //Doesn't select
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    //I want the increment inside of here, so it is performed when the function is called, otherwise doing it within the case statement was causing issues of it adjusting through the floor from update script prior to resizing, only for a frame but appeared jarring.
    //Block of code for the button functions
    public void ChangeScaleXP()
    {
        X++;
        rCube.transform.localScale = new Vector3(X, Y, Z);
    }
    public void ChangeScaleXM()
    {
        X--;
        rCube.transform.localScale = new Vector3(X, Y, Z);
    }
    public void ChangeScaleYP()
    {
        Y++;
        rCube.transform.localScale = new Vector3(X, Y, Z);
    }
    public void ChangeScaleYM()
    {
        Y--;
        rCube.transform.localScale = new Vector3(X, Y, Z);
    }
    public void ChangeScaleZP()
    {
        Z++;
        rCube.transform.localScale = new Vector3(X, Y, Z);
    }
    public void ChangeScaleZM()
    {
        Z--;
        rCube.transform.localScale = new Vector3(X, Y, Z);
    }

    //Sets the value of the scale to be the initial values, which also resets the Y position due to the check within the Update function.
    public void ResetScale()
    {
        X = sizeX;
        Y = sizeY;
        Z = sizeZ;
        rCube.transform.localScale = new Vector3 (sizeX, sizeY, sizeZ);
    }

    //Test function to turn a double into a float
    //Should be redundant at this point, but left it in for reminders sake
    public static float ToFloat(double value)
    {
        return (float)value;
    }
}