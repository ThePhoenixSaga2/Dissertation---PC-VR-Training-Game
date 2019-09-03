using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerComponent : MonoBehaviour {

    public static string ComponentName = ""; //Name of component
    public static string socketType = ""; //The socket the component will be installed on
    public static string hardwareType = ""; //What is the hardware

    //An array to store the details about that component
    public string[] component = {ComponentName, socketType, hardwareType};

    //Boolean to check if the component is installed in a socket or not
    public bool isComponentInstalled;

    private PlayerControls playerControls; //To access the isTriggerHeld booloen to detect if the user is holding down the trigger or not on the VR controller

    public Transform parentObject; //Reference the original parent object the component is placed in before it is picked up and installed

    private string socketName; //The name of the socket from the component array

    private void Start()
    {
        //This IF statements makes sure the references to each component and script is assigned to their respective variables
        if (parentObject == null)
        {
            parentObject = transform.parent.transform;
        }

        isComponentInstalled = false;
    }

    public bool SetComponentInstalledToTrue()
    {
        return isComponentInstalled = true;
    }

    public bool SetComponentInstalledToFalse()
    {
        return isComponentInstalled = false;
    }
}
