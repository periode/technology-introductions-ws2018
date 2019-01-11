using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col){
        
        // from the collision, we will deduce the gameobject involved
        // then its name

        //if the name of the object that has hit us is "Ball"
        if(col.gameObject.name == "Ball"){

            //destroy us
            Destroy(this.gameObject);
        }
        
    }
}
