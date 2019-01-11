using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleManager : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame -- rendering engine
	void Update () {
           
	}

    // WE NEED TO MOVE THE PADDLE
    // WE WANT TO APPLY A FORCE TO THE PADDLE
    // FORCES CAN ONLY BE APPLIED TO RIGIDBODIES
    // ANYTHING THAT HAPPENS TO A RIGIDBODY SHOULD HAPPEN IN FIXED UPDATE

    // physics engine
    private void FixedUpdate()
    {
        // if i press the left arrow, add a force to the left
        if(Input.GetKey(KeyCode.LeftArrow)){
            GetComponent<Rigidbody>().AddForce(new Vector3(-1.0f, 0f, 0f) * speed);  
        }

        //if i press the right arrow, add a force to the right
        if(Input.GetKey(KeyCode.RightArrow)){
            GetComponent<Rigidbody>().AddForce(new Vector3(1.0f, 0f, 0f) * speed);
        }

    }


}
