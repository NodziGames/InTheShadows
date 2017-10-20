using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_select : MonoBehaviour {

	// Use this for initialization
	public int level;
	public GameObject text_3d;
	public GameObject bubble;

	private Renderer rend;
	private Vector3 original_pos;
	private Vector3 hoverpos;
	private int	level_status;
	private AudioSource audio;

	private Color locked = Color.gray;
	private Color unlocked = new Color(18f / 255f, 73f / 255f, 137f / 255f);
	private Color completed = new Color(13f / 255f, 137f / 255f, 75f / 255f);

	private bool selected = false;

	void Start () {
		audio = GetComponent<AudioSource> ();
		rend = bubble.GetComponent<Renderer> ();
		text_3d.GetComponent<TextMesh> ().text = level.ToString();

		//Color Level Based On Status
		level_status = PlayerPrefs.GetInt("lvl_" + level, 0);

		if (level_status == 0 && level == 1)
			level_status = 1;

		if (PlayerPrefs.GetInt ("Classic") == 1)
			level_status = 2;

		if (level_status == 0)
		{
			rend.material.color = locked;
		}
		if (level_status == 1)
		{
			rend.material.color = unlocked;
		}
		if (level_status == 2)
		{
			rend.material.color = completed;
		}

		original_pos = this.transform.position;
		hoverpos = new Vector3 (original_pos.x, original_pos.y, original_pos.z + 0.3f);
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
		if (level_status != 0)
			selected = true;

		if (selected && Input.GetMouseButtonDown (0))
		{
			audio.Play ();
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.5f);
			Invoke ("GoToLevel", 0.4f);

		}
	}

	void OnMouseExit()
	{
		selected = false;
	}

	void GoToLevel()
	{
		SceneManager.LoadScene (level.ToString ());
	}
}