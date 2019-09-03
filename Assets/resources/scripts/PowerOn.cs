using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerOn : MonoBehaviour {

    //Access aniamtion for power button
    private Animator anim;

    //Access the timer which times how long the training simualtion has been running for
    private Timer timer;

    //To access the end timer UI to display the final time it took to finish the tutorial
    public Text endTimerUI;

    //To access the variable componentsIntsalled to determine if all of the components have been installed or not
    private CountingComponentInstallation countCompInstall;

    //Access the monitor screen UI on the monitor
    public Image monitorScreen;

    public Sprite screenOn; //Image of the on screen
    public Sprite screenOff; //Image of the off screen

    public GameObject screenOnMessage; //The success UI text
    public GameObject screenErrorMessage; //The error UI text

	// Use this for initialization
	void Start () {
        //These IF statements ensure that when the game starts up, these variables are assigned with their respective components and game objects.
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
        if (timer == null)
        {
            timer = GameObject.Find("GameManager").GetComponent<Timer>();
        }
        if (countCompInstall == null)
        {
            countCompInstall = GameObject.Find("GameManager").GetComponent<CountingComponentInstallation>();
        }

        //Turn off UI text for monitor at start of game
        screenOnMessage.SetActive(false);
        screenErrorMessage.SetActive(false);

        //By default a blank screen should be displayed on the monitor to show it is turned off
        monitorScreen.sprite = screenOff;

        endTimerUI.text = ""; //Clear the endTimerUI text at the start of the game

    }

    private void OnTriggerEnter(Collider other)
    {
        //If the user has touched the power button, play the button pressing animation and execute the PowerOnMonitor to check if all of the components have been installed.
        if (other.name == "WandCube")
        {
            anim.Play("Pressed");
            PowerOnMonitor();
        }
        Debug.Log(other.name + " Has collided with: " + gameObject.name);
    }

    private void PowerOnMonitor()
    {
        if (countCompInstall.componentsInstalled >= countCompInstall.numOfComponentsToInstall)
        {
            monitorScreen.sprite = screenOn; //Display the desktop image on screen
            screenOnMessage.SetActive(true); //Display the success UI message
            screenErrorMessage.SetActive(false); //Hide error message incase it is displayed
            endTimerUI.text = timer.GetTimer().ToString("F0") + "sec"; //Show the final time it took to complete the tutorial
        }
        else
        {
            monitorScreen.sprite = screenOff; //DIsplay the blank screen
            screenErrorMessage.SetActive(true); //Display the error UI message
            screenOnMessage.SetActive(false); //Hide success message incase it is displayed
        }
    }
}
