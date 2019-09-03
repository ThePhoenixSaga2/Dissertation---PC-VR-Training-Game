using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountingComponentInstallation : MonoBehaviour {

    public int numOfComponentsToInstall = 18;
    public int componentsInstalled;

	// Use this for initialization
	void Start () {
        componentsInstalled = 0;
    }
}
