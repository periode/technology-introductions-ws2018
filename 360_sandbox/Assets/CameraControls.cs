using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(new Vector3(0, -1, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(new Vector3(0, 1, 0));
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Rotate(new Vector3(-1, 0, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Rotate(new Vector3(1, 0, 0));
        }
	}
}
