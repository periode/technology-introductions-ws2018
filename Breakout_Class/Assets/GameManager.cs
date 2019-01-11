using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject brickPrefab;
    int number_of_columns = 8;
    int number_of_rows = 5;

	// Use this for initialization
	void Start () {
        for (float x = -5; x < number_of_columns; x+= 1.5f){ //this goes on the x axis and place a brick at each column

            for (float y = 0; y < number_of_rows; y += 1.5f){ //this goes on the y axis and place a brick at each row
                
                GameObject.Instantiate(brickPrefab, new Vector3(x, y, 0f), Quaternion.identity);

            }

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
