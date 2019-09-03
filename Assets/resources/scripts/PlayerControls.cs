using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiddleVR_Unity3D;


public class PlayerControls : MonoBehaviour {

    public bool isTriggerHeld; //To check if the user is holding down the trigger or not
    private bool wandButtonPressed0; //To reference the trigger on the VR controller to see if user presses or not
    private bool mouseButtomPressed0; //For debugging purposes, simulates VR tigger by checking left mouse button's state

    //Reference animation controller to playback the hand animations
    private Animator anim;

    //Run at the start of the game
    void Start() {
        isTriggerHeld = false; //Default to false

        if (anim == null)
        {
            anim = GameObject.Find("r_hand_bone").GetComponent<Animator>();
        }

    }

    void Update()
    {
        //MiddleVR.VRDeviceMgr.IsWandButtonPressed(0);
        //MiddleVR.VRDeviceMgr.IsMouseButtonPressed(0);

        // Getting state of primary wand button, also known as the trigger 
        wandButtonPressed0 = MiddleVR.VRDeviceMgr.IsWandButtonPressed(0);
        mouseButtomPressed0 = MiddleVR.VRDeviceMgr.IsMouseButtonPressed(0);
        //wandButtonPressed0 || mouseButtomPressed0

        //Is the trigger on VR controller active?
        if (wandButtonPressed0 || mouseButtomPressed0)
        {
            anim.SetBool("TriggerPressed", true);
            if (anim.GetBool("TriggerPressed") == true)
            {
                anim.Play("Grab");
            }
            
            SetTriggerTrue(); //User is holding the computer component
            //Debug.Log("Grab is: Active");
        }
        else {
            anim.SetBool("TriggerPressed", false);

            if (anim.GetBool("TriggerPressed") == false)
            {
                anim.Play("Release");
            }


            SetTriggerFalse(); //User is not holding the computer component
            //Debug.Log("Grab is: Not Active");
        }
    }

    //SetTriggerTrue and SetTriggerFalse alters the booloen value of isTriggerHeld between true and false
    public bool SetTriggerTrue()
    {
        isTriggerHeld = true;
        return isTriggerHeld;
    }

    public bool SetTriggerFalse()
    {
        isTriggerHeld = false;
        return isTriggerHeld;
    }
}