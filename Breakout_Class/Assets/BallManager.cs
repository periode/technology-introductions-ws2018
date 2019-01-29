using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {
    
    bool isLerping = false;
    Vector3 startPosition;
    Vector3 targetPosition;
    float lerpValue = 0f;

	// Use this for initialization
	void Start () {
        targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    // when we press the space bar


        // we want to get the ball moving



        //if the ball is below a certain level, lerp it back in place
        //lerp means linear interpolation > smoothly transition between two values

        // lerp(valueA (min), valueB, lerpValue); lerpValue is always between 0 and 1

        if(transform.position.y < -10){ //if we've gone beyond the screen
            GetComponent<Rigidbody>().velocity = Vector3.zero;

            if(isLerping == false){
                GameObject.Find("GameManager").GetComponent<GameManager>().totalLives -= 1; 
            }

            isLerping = true;
              

            startPosition = transform.position;
            GetComponent<Collider>().enabled = false;


        }

        if(isLerping == true){
            transform.position = Vector3.Lerp(startPosition, targetPosition, lerpValue);
            lerpValue += 0.01f; // here 0.1 is the speed at which we come back



            if(lerpValue >= 1){
                isLerping = false;
                lerpValue = 0;
                GetComponent<Collider>().enabled = true;
            }
        }
	}

    // physics calculations happen
    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space)){
            //generate a random number, to randomize the direction of our ball
            float randomNumber = Random.Range(-2f, 2f);

            //add the force
            GetComponent<Rigidbody>().AddForce(new Vector3(randomNumber, 1f, 0f), ForceMode.Impulse);
        }
    }
}
