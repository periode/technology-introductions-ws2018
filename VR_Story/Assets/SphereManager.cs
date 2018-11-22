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

    public void OnPointerEnteredMySphere(){
        Debug.Log("enter");
    }

    public void OnPointerExited(string isTrue){
        Debug.Log("exited");
        for (int i = 0; i < 100; i++)
        {
            Debug.Log("counting");
        }
    }
}
