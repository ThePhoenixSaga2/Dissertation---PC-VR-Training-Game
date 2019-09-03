using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerAssembly : MonoBehaviour {

    private PlayerControls playerControls; //To access the isTriggerHeld booloen to detect if the user is holding down the trigger or not on the VR controller
    private ComputerComponent computerComponent; //To access the isComponentInstalled boolean to detect if the component is installed or not

    private string componentName; //For debugging the name of component, from the component array
    private string socketName; //The name of the socket from the component array

    public Transform componentTransform; //The component's transform
    public Transform socketTransform; //To access the node object's transform attached to the socket object

    private CountingComponentInstallation countCompInstall;
   
    //Use this for initialization
    void Start () {
        //These IF statements makes sure the references to each component and script is assigned to their respective variables
        if (playerControls == null)
        {
            playerControls = GameObject.Find("WandCube").GetComponent<PlayerControls>(); ;
        }
        if(socketTransform == null)
        {
            socketTransform = gameObject.transform.Find("Node"); //Each socket should have a game object called node, where the component will be attached to, this simulates the component being installed in the socket
        }
        if (countCompInstall == null)
        {
            countCompInstall = GameObject.Find("GameManager").GetComponent<CountingComponentInstallation>();
        }
	}
	
	// Update is called once per frame
	void Update () {

        //If the socket does not contain an child object, in this case a component object, then enable the collider on the object
        //Enabling the box collider will allow the OnTrigger events to run to chekc if a component object touches the collision box on the socket
        if (socketTransform.childCount <= 0)
        {
            //Re-enable collidor
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Check if the "other" object is a computer part or component, if not then don't run the ComponentInstallation function
        if (other.tag == "ComputerParts")
        {
            ComponentInstallation(other);
        }
    }

    void ComponentInstallation(Collider other)
    {
        //Check if the name of the object this script is attached matches to the name of the socket assign int he collided objects array

        computerComponent = other.GetComponent<ComputerComponent>();
        componentName = computerComponent.component[0]; //For debugging the name of the component
        socketName = computerComponent.component[1]; //Retrieve the name of the socket that was assigned to the component array

        componentTransform = other.gameObject.GetComponent<Transform>(); //Access the transform of the socket object this script is attached to

        //Check if socket has a component game object attached, if not then perform the component checking
        if (socketTransform.childCount == 0)
        {
            //If the component is collding with socket collidor and the user is not holding down the trigger, place component in socket
            if (playerControls.isTriggerHeld == false)
            {
                //Check if the component socket name is the same as the name of this game object, if so then it is the correct socket for component to be installed on
                if (socketName == gameObject.name)
                {
                    InstallComponent(componentTransform, socketTransform, computerComponent);
                }
            }
        }
    }

    public void InstallComponent(Transform componentTransform, Transform socketTransform, ComputerComponent computerComponent)
    {
        componentTransform.parent = socketTransform; //Attach component to socket
        componentTransform.position = socketTransform.position; //Positions the component to the same position as the node object
        componentTransform.rotation = socketTransform.rotation; //Rotate the component to the same rotation as the node object

        //Set the booleon isComponentInstalled for that component to true
        computerComponent.SetComponentInstalledToTrue();

        //Add 1 to the variable componentsInstalled to show that a component has been installed
        countCompInstall.componentsInstalled++;
        Debug.Log("Components Installed: " + countCompInstall.componentsInstalled);

        //Disable collidor so the Trigger events are no longer running for the socket object that contains a component attached
        gameObject.GetComponent<BoxCollider>().enabled = false;

        //Disables the box collider on the component so the user cannot pick up the component again once it is installed
        componentTransform.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
