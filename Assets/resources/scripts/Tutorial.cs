using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    //These variables reference each tutorial screen
    public GameObject tutScreen_01; //Introduction
    public GameObject tutScreen_02; //Motherboard
    public GameObject tutScreen_03; //CPU
    public GameObject tutScreen_04; //RAM
    public GameObject tutScreen_05; //CPU Cooler
    public GameObject tutScreen_06; //Storage
    public GameObject tutScreen_07; //PSU
    public GameObject tutScreen_08; //Graphics Card
    public GameObject tutScreen_09; //Case Fan
    public GameObject tutScreen_10; //Motherboard Power Cable
    public GameObject tutScreen_11; //Graphics Card Power Cable
    public GameObject tutScreen_12; //Hard Drive Power Cable
    public GameObject tutScreen_13; //Hard Drive Data Cable 1
    public GameObject tutScreen_14; //Hard Drive Data Cable 2
    public GameObject tutScreen_15; //USB Mouse
    public GameObject tutScreen_16; //USB Keyboard
    public GameObject tutScreen_17; //Video Cable
    public GameObject tutScreen_18; //Computer Power

    //Number of components installed
    private int numOfComponentsInstalled;

    //To reference and gain access to the variable called numOfComponentsInstalled
    private CountingComponentInstallation countCompInstall;

    //Timer for when to switch the first tutorial screen to the second one to start the tutorial process
    private float time;
    private bool isCounting;

    //Access the timer text UI to display the countdown for when the first 
    private Text timerUI;

    //These variables reference the graphics markers, located above each component and socket
    public GameObject GI_01; //Motherboard
    public GameObject GI_02; //Case socket
    public GameObject GI_03; //CPU
    public GameObject GI_04; //CPU Socket
    public GameObject GI_05; //RAM 1
    public GameObject GI_06; //RAM 2
    public GameObject GI_07; //RAM Socket 1
    public GameObject GI_08; //RAM Socket 2
    public GameObject GI_09; //CPU Cooler
    public GameObject GI_10; //CPU Cooler Socket (on top of CPU)
    public GameObject GI_11; //Hard Drive
    public GameObject GI_12; //Hard Drive Socket
    public GameObject GI_13; //Power Supply
    public GameObject GI_14; //Power Socket
    public GameObject GI_15; //Graphics Card
    public GameObject GI_16; //PCIe Socket
    public GameObject GI_17; //Fan
    public GameObject GI_18; //Fan Socket
    public GameObject GI_19; //Fan Power Cable
    public GameObject GI_20; //Fan Power Socket
    public GameObject GI_21; //Motherboard Power Cable
    public GameObject GI_22; //Motherboard Power Socket
    public GameObject GI_23; //Graphics Card Power Cable
    public GameObject GI_24; //Graphics Card Power Socket
    public GameObject GI_25; //SATA Power Cable
    public GameObject GI_26; //Hard Drive Power Socket
    public GameObject GI_27; //SATA Data Cable 1
    public GameObject GI_28; //Hard Drive Data socket
    public GameObject GI_29; //SATA Data Cable 2
    public GameObject GI_30; //SATA Socket
    public GameObject GI_31; //USB Mouse Cable
    public GameObject GI_32; //Motherboard IO Ports
    public GameObject GI_33; //USB Keyboard Cable
    public GameObject GI_34; //Motherboard IO Ports
    public GameObject GI_35; //Video Output Cables
    public GameObject GI_36; //Graphics Card Video Socket
    public GameObject GI_37; //PSU Cable
    public GameObject GI_38; //Power Sockets 2

    // Use this for initialization
    void Start () {

        //The first tutroial screen should be displayed, all other tutorial screens should be disabled at the start of the game
        tutScreen_01.SetActive(true); //Introduction
        tutScreen_02.SetActive(false); //Motherboard
        tutScreen_03.SetActive(false); //CPU
        tutScreen_04.SetActive(false); //RAM
        tutScreen_05.SetActive(false); //CPU Cooler
        tutScreen_06.SetActive(false); //Storage
        tutScreen_07.SetActive(false); //PSU
        tutScreen_08.SetActive(false); //Graphics Card
        tutScreen_09.SetActive(false); //Case Fan
        tutScreen_10.SetActive(false); //Motherboard Power Cable
        tutScreen_11.SetActive(false); //Graphics Card Power Cable
        tutScreen_12.SetActive(false); //Hard Drive Power Cable
        tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
        tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
        tutScreen_15.SetActive(false); //USB Mouse
        tutScreen_16.SetActive(false); //USB Keyboard
        tutScreen_17.SetActive(false); //Video Cable
        tutScreen_18.SetActive(false); //Computer Power

        //Hide all of the graphics icons at the start of the game
        GI_01.SetActive(false); //Motherboard
        GI_02.SetActive(false); //Case socket
        GI_03.SetActive(false); //CPU
        GI_04.SetActive(false); //CPU Socket
        GI_05.SetActive(false); //RAM 1
        GI_06.SetActive(false); //RAM 2
        GI_07.SetActive(false); //RAM Socket 1
        GI_08.SetActive(false); //RAM Socket 2
        GI_09.SetActive(false); //CPU Cooler
        GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
        GI_11.SetActive(false); //Hard Drive
        GI_12.SetActive(false); //Hard Drive Socket
        GI_13.SetActive(false); //Power Supply
        GI_14.SetActive(false); //Power Socket
        GI_15.SetActive(false); //Graphics Card
        GI_16.SetActive(false); //PCIe Socket
        GI_17.SetActive(false); //Fan
        GI_18.SetActive(false); //Fan Socket
        GI_19.SetActive(false); //Fan Power Cable
        GI_20.SetActive(false); //Fan Power Socket
        GI_21.SetActive(false); //Motherboard Power Cable
        GI_22.SetActive(false); //Motherboard Power Socket
        GI_23.SetActive(false); //Graphics Card Power Cable
        GI_24.SetActive(false); //Graphics Card Power Socket
        GI_25.SetActive(false); //SATA Power Cable
        GI_26.SetActive(false); //Hard Drive Power Socket
        GI_27.SetActive(false); //SATA Data Cable 1
        GI_28.SetActive(false); //Hard Drive Data socket
        GI_29.SetActive(false); //SATA Data Cable 2
        GI_30.SetActive(false); //SATA Socket
        GI_31.SetActive(false); //USB Mouse Cable
        GI_32.SetActive(false); //Motherboard IO Ports
        GI_33.SetActive(false); //USB Keyboard Cable
        GI_34.SetActive(false); //Motherboard IO Ports
        GI_35.SetActive(false); //Video Output Cables
        GI_36.SetActive(false); //Graphics Card Video Socket
        GI_37.SetActive(false); //PSU Cable
        GI_38.SetActive(false); //Power Sockets 2

        //Ensures that at start up, countCompInstall is assigned with the script from GameManager
        if (countCompInstall == null)
        {
            countCompInstall = GameObject.Find("GameManager").GetComponent<CountingComponentInstallation>();
        }

        if (timerUI == null)
        {
            timerUI = GameObject.Find("Timer").GetComponent<Text>();
        }

        //How long the timer will run before starting the tutorial
        time = 30.0f;
        isCounting = true;
        timerUI.text = "30";
}

    // Update is called once per frame
    void Update() {

        if (isCounting == true)
        {
            StartTutorial();
        }
        
        SwtichingTutorialScreens();
    }

    void StartTutorial()
    {
        time -= Time.deltaTime;
        if (time < 1.0f)
        {
            //Start the tutorial process by switching to the second tutorial screen and await the user to start installing components before swtching to the next tutorial screen.
            countCompInstall.componentsInstalled++;
            isCounting = false;
        }
        timerUI.text = time.ToString("F0");
    }

    void SwtichingTutorialScreens()
    {
        switch (countCompInstall.componentsInstalled)
        {
            case 0:
                tutScreen_01.SetActive(true); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 1:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(true); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(true); //Motherboard
                GI_02.SetActive(true); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 2:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(true); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(true); //CPU
                GI_04.SetActive(true); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(true); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 3:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(true); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(true); //RAM 1
                GI_06.SetActive(true); //RAM 2
                GI_07.SetActive(true); //RAM Socket 1
                GI_08.SetActive(true); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 4:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(true); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(true); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(true); //CPU Cooler
                GI_10.SetActive(true); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 5:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(true); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(true); //Hard Drive
                GI_12.SetActive(true); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 6:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(true); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(true); //Power Supply
                GI_14.SetActive(true); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 7:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(true); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(true); //Graphics Card
                GI_16.SetActive(true); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 8:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(true); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(true); //Fan
                GI_18.SetActive(true); //Fan Socket
                GI_19.SetActive(true); //Fan Power Cable
                GI_20.SetActive(true); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 9:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(true); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(true); //Fan
                GI_18.SetActive(true); //Fan Socket
                GI_19.SetActive(true); //Fan Power Cable
                GI_20.SetActive(true); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 10:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(true); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(true); //Motherboard Power Cable
                GI_22.SetActive(true); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 11:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(true); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(true); //Graphics Card Power Cable
                GI_24.SetActive(true); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 12:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(true); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(true); //SATA Power Cable
                GI_26.SetActive(true); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 13:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(true); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(true); //SATA Data Cable 1
                GI_28.SetActive(true); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 14:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(true); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(true); //SATA Data Cable 2
                GI_30.SetActive(true); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 15:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(true); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(true); //USB Mouse Cable
                GI_32.SetActive(true); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(true); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 16:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(true); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(true); //Motherboard IO Ports
                GI_33.SetActive(true); //USB Keyboard Cable
                GI_34.SetActive(true); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 17:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(true); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(true); //Video Output Cables
                GI_36.SetActive(true); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            case 18:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(true); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(true); //PSU Cable
                GI_38.SetActive(true); //Power Sockets 2
                break;
            case 19:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(true); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
            default:
                tutScreen_01.SetActive(false); //Introduction
                tutScreen_02.SetActive(false); //Motherboard
                tutScreen_03.SetActive(false); //CPU
                tutScreen_04.SetActive(false); //RAM
                tutScreen_05.SetActive(false); //CPU Cooler
                tutScreen_06.SetActive(false); //Storage
                tutScreen_07.SetActive(false); //PSU
                tutScreen_08.SetActive(false); //Graphics Card
                tutScreen_09.SetActive(false); //Case Fan
                tutScreen_10.SetActive(false); //Motherboard Power Cable
                tutScreen_11.SetActive(false); //Graphics Card Power Cable
                tutScreen_12.SetActive(false); //Hard Drive Power Cable
                tutScreen_13.SetActive(false); //Hard Drive Data Cable 1
                tutScreen_14.SetActive(false); //Hard Drive Data Cable 2
                tutScreen_15.SetActive(false); //USB Mouse
                tutScreen_16.SetActive(false); //USB Keyboard
                tutScreen_17.SetActive(false); //Video Cable
                tutScreen_18.SetActive(false); //Computer Power

                GI_01.SetActive(false); //Motherboard
                GI_02.SetActive(false); //Case socket
                GI_03.SetActive(false); //CPU
                GI_04.SetActive(false); //CPU Socket
                GI_05.SetActive(false); //RAM 1
                GI_06.SetActive(false); //RAM 2
                GI_07.SetActive(false); //RAM Socket 1
                GI_08.SetActive(false); //RAM Socket 2
                GI_09.SetActive(false); //CPU Cooler
                GI_10.SetActive(false); //CPU Cooler Socket (on top of CPU)
                GI_11.SetActive(false); //Hard Drive
                GI_12.SetActive(false); //Hard Drive Socket
                GI_13.SetActive(false); //Power Supply
                GI_14.SetActive(false); //Power Socket
                GI_15.SetActive(false); //Graphics Card
                GI_16.SetActive(false); //PCIe Socket
                GI_17.SetActive(false); //Fan
                GI_18.SetActive(false); //Fan Socket
                GI_19.SetActive(false); //Fan Power Cable
                GI_20.SetActive(false); //Fan Power Socket
                GI_21.SetActive(false); //Motherboard Power Cable
                GI_22.SetActive(false); //Motherboard Power Socket
                GI_23.SetActive(false); //Graphics Card Power Cable
                GI_24.SetActive(false); //Graphics Card Power Socket
                GI_25.SetActive(false); //SATA Power Cable
                GI_26.SetActive(false); //Hard Drive Power Socket
                GI_27.SetActive(false); //SATA Data Cable 1
                GI_28.SetActive(false); //Hard Drive Data socket
                GI_29.SetActive(false); //SATA Data Cable 2
                GI_30.SetActive(false); //SATA Socket
                GI_31.SetActive(false); //USB Mouse Cable
                GI_32.SetActive(false); //Motherboard IO Ports
                GI_33.SetActive(false); //USB Keyboard Cable
                GI_34.SetActive(false); //Motherboard IO Ports
                GI_35.SetActive(false); //Video Output Cables
                GI_36.SetActive(false); //Graphics Card Video Socket
                GI_37.SetActive(false); //PSU Cable
                GI_38.SetActive(false); //Power Sockets 2
                break;
        }
    }
}
