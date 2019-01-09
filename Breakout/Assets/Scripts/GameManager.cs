using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    public GameObject brick;
    public Camera mainCam;
    public AudioManager audioManager;

    int columns = 9;
    int rows = 4;

    private int score = 0;
    private int lives = 3;

    private Text scoreUI;
    private Text livesUI;
    private Image globalFade;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null){
            
            Instance = this;

        } else if(Instance != this){
            
            Destroy(gameObject);

        }

        globalFade = GameObject.Find("Fade").GetComponent<Image>();

        scoreUI = GameObject.Find("Score").GetComponent<Text>();
        scoreUI.text = "Score: " + score;
        livesUI = GameObject.Find("Lives").GetComponent<Text>();
        livesUI.text = "Lives: " + lives;
    }

    // Use this for initialization
    void Start () {

        // this double for loop creates a grid
        // at each point on the grid we create a brick by instantiating one of our prefabs
        for (int x = 0; x < columns; x++){
            for (int y = 0; y < rows; y++){
                Vector3 spawnPosition;

                // the screenToWorldPoint method allows us to choose exactly where we want our position to be in terms of the screen size
                // here, we want to start at 10% of the width of the screen, all the way to 90%
                spawnPosition = mainCam.ScreenToWorldPoint(new Vector3(mainCam.pixelWidth * (0.1f + x * 0.1f), mainCam.pixelHeight * (0.9f-y*0.075f), 10f));
                GameObject.Instantiate(brick, spawnPosition, Quaternion.identity);
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void Loose(){
        // start increasing the alpha of the FADE UI object
        globalFade.color = new Color(0f, 0f, 0f, 0f);
        StartCoroutine("Fade");

        // check the ending audio clip duration
        float clip_duration = GetComponent<AudioSource>().clip.length;
        // and then play it
        GetComponent<AudioSource>().Play();

        // save the current score
        PlayerPrefs.SetInt(PlayerPrefs.GetString("currentPlayer"), score);
        PlayerPrefs.Save();

        //delay the loading of the last scene just a little bit to get to 
        Invoke("LoadLastScene", clip_duration);
    }

    void LoadLastScene(){
        SceneManager.LoadScene("End");
    }

    void Win(){
        globalFade.color = new Color(255f, 255f, 255f, 0f);
        StartCoroutine("Fade");
        PlayerPrefs.SetInt(PlayerPrefs.GetString("currentPlayer"), score);
        PlayerPrefs.Save();
        Invoke("LoadLastScene", 3);
    }

    private IEnumerator Fade(){
        while(globalFade.color.a < 255){
            yield return new WaitForSeconds(0.1f);
            globalFade.color = new Color(globalFade.color.r, globalFade.color.g, globalFade.color.b, globalFade.color.a + 0.1f);
        }
    }



    public void ModifyScore(int mod){
        score += mod; 
        scoreUI.text = "Score: " + score;

        if (rows*columns == score)
            Win();
    }

    public void ModifyLives(int mod)
    {
        

        if (lives == 0){
            Loose();
        }else{
            lives += mod;
            livesUI.text = "Lives: " + lives;

            if(lives == 1){
                AudioManager.Instance.SetAudioState("Almost Dead");
            }
        }
            
    }

}
