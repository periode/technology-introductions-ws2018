using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
    void Update () {

    }

    // this function will be called when the raycast hits that object (RaycastManager.cs line 40)
    public void ShowSphere(){

      // this enables the Renderer component, making the object visible
      GetComponent<Renderer>().enabled = true;
    }

    // we wrote this function that is going to be called from our raycasting script (RaycastManager.cs line 48)
    public void Reset(){
        GetComponent<Renderer>().enabled = false;
    }
}
