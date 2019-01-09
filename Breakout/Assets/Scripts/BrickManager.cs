using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour {

    bool readyToDestroy = false;
    public GameObject explosion;

	// Use this for initialization
	void Start () {
        float rand = Random.value * 20f;
        InvokeRepeating("StartAnimation", rand, 2f);
	}

    void StartAnimation(){
        GetComponent<Animator>().Play("BrickLoop");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball"){
            if(!readyToDestroy){
                GameManager.Instance.ModifyScore(1);
                GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                readyToDestroy = true;
            }

        }
    }
}
