using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_reset : MonoBehaviour {

	// Use this for initialization
	public GameObject bubble;

	private Vector3 original_pos;
	private Vector3 hoverpos;
	private AudioSource audio;

	private bool selected = false;

	void Start () {
		original_pos = this.transform.position;
		hoverpos = new Vector3 (original_pos.x, original_pos.y, original_pos.z + 0.3f);
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (selected)
			this.transform.position = Vector3.Lerp (this.transform.position, hoverpos, 0.1f);
		else
			this.transform.position = Vector3.Lerp (this.transform.position, original_pos, 0.1f);
		
	}

	void OnMouseOver()
	{
		selected = true;

		if (selected && Input.GetMouseButtonDown (0))
		{
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.5f);
			PlayerPrefs.DeleteAll ();
			PlayerPrefs.Save ();
			audio.Play ();
		}
	}

	void OnMouseExit()
	{
		selected = false;
	}
}