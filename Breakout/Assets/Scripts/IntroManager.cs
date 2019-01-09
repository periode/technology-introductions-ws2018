using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // this function is going to be called from the Start Button
    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    // this function is going to be called whenever we click away from
    public void SavePlayerName(string playerName){

        // if the player has entered a correct string
        if (playerName.Length > 0){
            PlayerPrefs.SetString("currentPlayer", playerName);
            PlayerPrefs.SetInt(playerName, 0); //-- initialize a new player preference
            PlayerPrefs.SetString("players", PlayerPrefs.GetString("players") + playerName + ","); //-- save it with all the other player names
                                                                                                   //-- could also work with this http://wiki.unity3d.com/index.php/ArrayPrefs2
            GameObject.Find("Button Start").GetComponent<Button>().interactable = true;
        }else{
            GameObject.Find("Button Start").GetComponent<Button>().interactable = false;
        }
    }
}
