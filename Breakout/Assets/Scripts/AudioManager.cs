using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public AudioMixer mixer;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        if(GameObject.FindGameObjectsWithTag("AudioManager").Length > 1){
            Destroy(this.gameObject);
        }else{
            DontDestroyOnLoad(this.gameObject);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetAudioState(string snap){
        AudioMixerSnapshot snapshot = mixer.FindSnapshot(snap);
        snapshot.TransitionTo(5.0f);
    }
}
