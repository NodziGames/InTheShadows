using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

	// Use this for initialization
	public float pan_range;

	private Quaternion default_rot;

	void Start () {
		default_rot = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		float mousex_normalized = (Input.mousePosition.x - (Screen.width / 2)) / (Screen.width / 2);
		this.transform.rotation = Quaternion.Euler(default_rot.x, 25.968f + (mousex_normalized * pan_range), default_rot.z);
	}
}
