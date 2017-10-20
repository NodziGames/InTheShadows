using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_mute : MonoBehaviour {

	// Use this for initialization
	private Vector3 original_pos;
	private Vector3 hoverpos;
	private AudioSource audio;

	private Renderer rend;
	private Color on_color = new Color(187f / 255f, 111f / 255f, 96f / 255f);

	private bool selected = false;

	void Start () {
		original_pos = this.transform.position;
		rend = GetComponent<Renderer> ();
		hoverpos = new Vector3 (original_pos.x, original_pos.y, original_pos.z + 0.3f);
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (selected)
			this.transform.position = Vector3.Lerp (this.transform.position, hoverpos, 0.1f);
		else
			this.transform.position = Vector3.Lerp (this.transform.position, original_pos, 0.1f);

		if (PlayerPrefs.GetInt ("Volume", 1) == 0)
			rend.material.color = Color.gray;
		else
			rend.material.color = on_color;
	}

	void OnMouseOver()
	{
		selected = true;

		if (selected && Input.GetMouseButtonDown (0))
		{
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.5f);
			if (PlayerPrefs.GetInt ("Volume", 1) == 0)
				PlayerPrefs.SetInt ("Volume", 1);
			else
				PlayerPrefs.SetInt ("Volume", 0);
			PlayerPrefs.Save ();
			audio.Play ();
		}
	}

	void OnMouseExit()
	{
		selected = false;
	}
}