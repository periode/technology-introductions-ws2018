using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(GvrControllerInput.ClickButtonDown);
	}

    public void OnPointedSphere(){
        Debug.Log("pointed");
    }

    public void OnClickedSphere()
    {
        Debug.Log("click");
        SceneManager.LoadScene(1);
    }
}
