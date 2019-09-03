using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiddleVR_Unity3D;

public class Pickup : MonoBehaviour {

    public PlayerControls playerControls; //To reference isTriggerHeld boolean and its functions to alter its true/false state
    private bool wandButtonPressed0; //To reference the trigger on the VR controller to see if user presses or not

    private GameObject vrHand;

    private void Start()
    {
        vrHand = GameObject.Find("WandCube");
    }

    // Update is called once per frame
    void Update () {
        //MiddleVR.VRDeviceMgr.IsWandButtonPressed(0);
        //MiddleVR.VRDeviceMgr.IsMouseButtonPressed(0);

        // Getting state of primary wand button, also known as the trigger 
        wandButtonPressed0 = MiddleVR.VRDeviceMgr.IsMouseButtonPressed(0);

        //If user holds down the trigger
        if (wandButtonPressed0)
        {
            playerControls.SetTriggerTrue();
            Debug.Log("Grab is active");
        }
    }

    private void GrabComponent(Collider component)
    {
        component.gameObject.transform.parent = vrHand.transform;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (playerControls.isTriggerHeld == true)
        {
            GrabComponent(other.collider);
        }

        Debug.Log("VR Hand Touching: " + other.collider.name);
    }
}
