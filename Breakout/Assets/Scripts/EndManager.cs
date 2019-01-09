using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour {

    Text names;
    Text scores;

    ArrayList allNames;

    void Awake () {
        names = GameObject.Find("Names").GetComponent<Text>();
        scores = GameObject.Find("Scores").GetComponent<Text>();

        allNames = new ArrayList();
    }
	// Use this for initialization
    void Start () {
        
        string[] players = PlayerPrefs.GetString("players").Split(',');

        for (int i = 0; i < players.Length; i++){
            allNames.Add(players[i]);
        }

        while(allNames.Count > 1){
            
            float highest_score = -10;
            string highest_name = "";
            int highest_index = -1;

            foreach(string n in allNames){
                if (PlayerPrefs.GetInt(n) > highest_score && n != "")
                {
                    highest_score = PlayerPrefs.GetInt(n);
                    highest_name = n;
                    highest_index = allNames.IndexOf(n);
                }
            }

            names.text += "\n" + highest_name;
            scores.text += "\n" + highest_score;

            allNames.RemoveAt(highest_index);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Restart(){
        SceneManager.LoadScene("Intro");
    }

    void SetScore(string name, int score){
        PlayerPrefs.SetString("players", PlayerPrefs.GetString("players") + name + ",");
        PlayerPrefs.SetInt(name, score);
        PlayerPrefs.Save();
    }
}
