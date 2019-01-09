using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleManager : MonoBehaviour {
    
    public float speed;

    Camera mainCam;

    private void Awake()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > mainCam.ScreenToWorldPoint(new Vector3(mainCam.pixelWidth*0.1f, 0.0f, 0.0f)).x)
        {
            transform.GetComponent<Rigidbody>().AddForce(Vector3.left * speed, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < mainCam.ScreenToWorldPoint(new Vector3(mainCam.pixelWidth*0.9f, 0.0f, 0.0f)).x)
        {
            transform.GetComponent<Rigidbody>().AddForce(Vector3.right * speed, ForceMode.Acceleration);
        }
    }
}
