using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    // when we press the space bar


        // we want to get the ball moving
	}

    // physics calculations happen
    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space)){
            //generate a random number, to randomize the direction of our ball
            float randomNumber = Random.Range(-2f, 2f);

            //add the force
            GetComponent<Rigidbody>().AddForce(new Vector3(randomNumber, 2f, 0f), ForceMode.Impulse);
        }
    }
}
