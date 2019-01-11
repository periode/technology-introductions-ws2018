using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this is a new namespace, specific for UI stuff
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
        // we access the value of the variable "playerName"
        string lastPlayerName = PlayerPrefs.GetString("playerName");

        // FIND THE GAME OBJECT
        GameObject UIText = GameObject.Find("Placeholder");

        // FIND THE COMPONENT
        Text myTextComponent = UIText.GetComponent<Text>();

        // DO THE RIGHT THING
        myTextComponent.text = "Hello " + lastPlayerName + "!";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // this is the function that will be called by our input field
    public void SavePlayerName(string name){
        Debug.Log(name);

        // it saves the value `name` under the variable "playerName"
        PlayerPrefs.SetString("playerName", name);
    }

    public void LoadMainScene(){
        // we load the scene (remember to add `using Unity.SceneManagement;` at the top of the file!
        SceneManager.LoadScene("Main");
    }
}
