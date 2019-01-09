using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

    public bool isPlaying = false;
    bool isReturning = false;
    Vector3 startPosition;
    Vector3 loosePosition;
    float lerpAmount = 0f;
    public float initialSpeed = 20.0f;

	// Use this for initialization
	void Start () {
        startPosition = new Vector3(0f, -3.5f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (!isPlaying && !isReturning && Input.GetKeyDown(KeyCode.Space))
        {
           StartBall();
        }

        if(transform.position.y < -7 && !isReturning){
            GameManager.Instance.ModifyLives(-1);
            Reset();
        }

        if(isReturning){
            transform.position = Vector3.Lerp(loosePosition, startPosition, lerpAmount);
            lerpAmount += 0.05f;

            if(Vector3.Distance(transform.position, startPosition) < 0.1f){
                transform.position = startPosition;
                isReturning = false;
                lerpAmount = 0;
                GetComponent<SphereCollider>().enabled = true;
            }
        }
	}

    private void Reset()
    {
        transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        loosePosition = transform.position;
        GetComponent<SphereCollider>().enabled = false;
        isPlaying = false;
        isReturning = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Paddle"){ // -- this adds a little boost when you hit the paddle at an angle
            
            GetComponent<Rigidbody>().AddForce(new Vector3((transform.position.x - collision.gameObject.transform.position.x) * 0.5f, 0.0f, 0f), ForceMode.Impulse);

        }else if(collision.gameObject.name == "Side Wall" && Mathf.Abs(GetComponent<Rigidbody>().velocity.y) < 1.5f ){ //this adds a litle boost
            
            GetComponent<Rigidbody>().AddForce(new Vector3(0f, (GetComponent<Rigidbody>().velocity.y+0.1f)*5f, 0f), ForceMode.Impulse);

        }else{
            //GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity*-1);
        }
    }

    public void StartBall(){
        isPlaying = true;
        Vector3 randomInitialVelocity = new Vector3(Random.Range(-1f, 1f)*initialSpeed, initialSpeed, 0f);
        GetComponent<Rigidbody>().velocity = randomInitialVelocity;
    }
}
