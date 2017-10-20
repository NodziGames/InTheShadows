using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gay : MonoBehaviour {

	// Use this for initialization
	private AudioListener audio_listener;

	void Start () {
		audio_listener = GetComponent<AudioListener> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("Volume", 1) == 0)
			audio_listener.enabled = false;
		else
			audio_listener.enabled = true;
		
	}
}
