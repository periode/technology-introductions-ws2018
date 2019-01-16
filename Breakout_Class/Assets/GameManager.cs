using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour {

    public Image fadeImage;

    public AudioMixer mixer;

    public GameObject brickPrefab;
    int number_of_columns = 8;
    int number_of_rows = 5;

    public int totalLives = 1;



	// Use this for initialization
	void Start () {
        for (int x = -5; x < number_of_columns; x++ ){ //this goes on the x axis and place a brick at each column

            for (int y = 0; y < number_of_rows; y++){ //this goes on the y axis and place a brick at each row
                
                GameObject.Instantiate(brickPrefab, new Vector3(x*1.5f, y*1.5f, 0f), Quaternion.identity);

            }

        }
	}

    IEnumerator Fade(){
        for (int i = 0; i < 10; i++)
        {
            float alpha = i * 0.1f;
            //casting is forcing a variable type to another type

            fadeImage.color = new Color(0, 0, 0, alpha);
            //wait for 0.1sec
            Debug.Log(alpha);
            yield return new WaitForSeconds(0.1f);
        }
    }

    // a flag is a boolean variable that makes sure a certain event doesn't get repeated in an update loop
    bool isFading = false;

    void LoadLastScene(){
        SceneManager.LoadScene("End");
    }

    bool hasTransitioned = false;
	// Update is called once per frame
	void Update () {

        if(totalLives < 3 && !hasTransitioned){
            mixer.FindSnapshot("Almost Dead").TransitionTo(6.0f);
            hasTransitioned = false;
        }
        if(totalLives == 0){
            // fade the screen


            // couroutines > a kind of function that enables you to wait between instructions inside that function
            if(!isFading){
                StartCoroutine(Fade());
                float duration_of_the_sound = GetComponent<AudioSource>().clip.length;
                GetComponent<AudioSource>().Play();

                //invoke is going to execute a given function, after a given amount of time
                Invoke("LoadLastScene", duration_of_the_sound);

                isFading = true;
            }

            // play a sound effect


            // load the next scene when the sound effect is done

            // invoke
        }
	}
}
