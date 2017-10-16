using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_easy : MonoBehaviour {

	// Use this for initialization
	public Vector3 winning_coords;
	public float leniency;

	private float rotatespeed = 300.0f;
	private bool won = false;

	void Start () {
		bool izok = false;
		while (!izok)
		{
			transform.eulerAngles = new Vector3 (0, Random.Range(1.0f, 359.0f), 0);
			float offset_x = Mathf.Abs (winning_coords.x - transform.rotation.eulerAngles.x);
			float offset_y = Mathf.Abs (winning_coords.y - transform.rotation.eulerAngles.y);
			float offset_z = Mathf.Abs (winning_coords.z - transform.rotation.eulerAngles.z);
			if (offset_x <= leniency && offset_y <= leniency && offset_z <= leniency) {
				izok = false;
			} else
				izok = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!won) {
			if (Input.GetMouseButton (0)) {
				float rotateamounty = Input.GetAxis ("Mouse X") * rotatespeed * Time.deltaTime;
				transform.Rotate (0, rotateamounty, 0);
			} else {
				float offset_x = Mathf.Abs (winning_coords.x - transform.rotation.eulerAngles.x);
				float offset_y = Mathf.Abs (winning_coords.y - transform.rotation.eulerAngles.y);
				float offset_z = Mathf.Abs (winning_coords.z - transform.rotation.eulerAngles.z);
				if (offset_x <= leniency && offset_y <= leniency && offset_z <= leniency) {
					won = true;
					Debug.Log ("You Win!");
				}
			}
		} else {
			float newx = Mathf.Lerp (transform.rotation.eulerAngles.x, winning_coords.x, 0.1f);
			float newy = Mathf.Lerp (transform.rotation.eulerAngles.y, winning_coords.y, 0.1f);
			float newz = Mathf.Lerp (transform.rotation.eulerAngles.z, winning_coords.z, 0.1f);

			transform.eulerAngles = new Vector3(newx, newy, newz);
		}
	}
}
