using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour {

	// Use this for initialization

	public GameObject text;
	public string scene;
	public bool classic;

	private Renderer rend;
	private Vector3 original_pos;
	private Vector3 hoverpos;
	private AudioSource audio;

	void Start ()
	{
		rend = text.GetComponent<Renderer> ();
		rend.material.color = Color.grey;
		original_pos = this.transform.position;
		hoverpos = new Vector3 (original_pos.x, original_pos.y, original_pos.z + 0.3f);
		audio = GetComponent<AudioSource> ();
	}
	// Update is called once per frame
	void Update ()
	{
		if (rend.material.color == Color.white)
		{
			this.transform.position = Vector3.Lerp (this.transform.position, hoverpos, 0.1f);
		}
		else
		{
			this.transform.position = Vector3.Lerp (this.transform.position, original_pos, 0.1f);
		}
	}

	void OnMouseOver()
	{
		rend.material.color = Color.white;
		if (Input.GetMouseButtonDown (0))
		{
			audio.Play ();
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.5f);
			Invoke ("NextRoom", 0.4f);
		}
	}

	void NextRoom()
	{
		if (classic)
			PlayerPrefs.SetInt ("Classic", 1);
		else
			PlayerPrefs.SetInt ("Classic", 0);
		PlayerPrefs.Save ();
		SceneManager.LoadScene (scene);
	}

	void OnMouseExit()
	{
		rend.material.color = Color.grey;
	}
}
