using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiddleVR_Unity3D;

public class Drop : MonoBehaviour {

    public PlayerControls playerControls; //To reference isTriggerHeld boolean and its functions to alter its true/false state
    private bool wandButtonPressed0; //To reference the trigger on the VR controller to see if user presses or not

    private GameObject vrHand;
    private Transform component;

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

        //If user releases the trigger
        if (!wandButtonPressed0)
        {
            playerControls.SetTriggerFalse();

            DropComponent(); //Function to drop component user is holding
            Debug.Log("Grab is deactivated");
        }
	}

    private void DropComponent()
    {
        if (playerControls.isTriggerHeld == false)
        {
            //vrHand.GetComponentInChildren<Transform>().parent == null;
            //component.gameObject.transform.parent = vrHand.transform;
            //component = vrHand.GetComponentInChildren<Transform>(); //Access transform from the computer component object that would've been attached to the WandHand object

            //component.parent = null; //Removes the computer component object from the WandHand object
        }
    }
}
