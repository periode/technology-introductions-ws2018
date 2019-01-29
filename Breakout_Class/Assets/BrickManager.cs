using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //InvokeRepeating("PlayAnimation", Random.Range(1.0f, 4.0f), Random.Range(5.0f, 8.0f));
		
	}

    void PlayAnimation(){
        GetComponent<Animator>().Play("BrickFlip");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col){
        
        // from the collision, we will deduce the gameobject involved
        // then its name

        //if the name of the object that has hit us is "Ball"
        if(col.gameObject.name == "Ball"){

            GetComponent<ParticleSystem>().Play();
            GameObject.Find("GameManager").GetComponent<GameManager>().score++;
            //destroy us
            //Destroy(this.gameObject);
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
        
    }
}
