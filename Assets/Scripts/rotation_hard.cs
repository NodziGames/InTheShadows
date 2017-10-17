using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_hard : MonoBehaviour {

	// Use this for initialization
	public Vector3 winning_coords;
	public float leniency;

	private float rotatespeed = 300.0f;
	private float movespeed = 20.0f;
	public bool angle_won = false;
	public bool pos_won = false;
	public int mouse_button;

	void Start () {
		bool izok = false;
		while (!izok)
		{
			transform.eulerAngles = new Vector3 (Random.Range(1.0f, 359.0f), Random.Range(1.0f, 359.0f), 0);
			float offset_x = Mathf.Abs (winning_coords.x - transform.rotation.eulerAngles.x);
			float offset_y = Mathf.Abs (winning_coords.y - transform.rotation.eulerAngles.y);
			if ((offset_x <= leniency || offset_x >= 180 - leniency) && offset_y <= leniency ) {
				izok = false;
			} else
				izok = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (!angle_won) {
			if (Input.GetMouseButton (mouse_button) && !Input.GetKey (KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift)) {
				float rotateamounty = Input.GetAxis ("Mouse X") * rotatespeed * Time.deltaTime;
				transform.Rotate (0, rotateamounty, 0);
			} else if (Input.GetMouseButton (mouse_button) && Input.GetKey (KeyCode.LeftControl)) {
				float rotateamountx = Input.GetAxis ("Mouse X") * rotatespeed * Time.deltaTime;
				transform.Rotate (rotateamountx, 0, 0);
			} else {
				float offset_x = Mathf.Abs(Mathf.DeltaAngle (winning_coords.x, transform.rotation.eulerAngles.x));
				float offset_y = Mathf.Abs(Mathf.DeltaAngle (winning_coords.y, transform.rotation.eulerAngles.y));
				float offset_z = Mathf.Abs(Mathf.DeltaAngle (winning_coords.z, transform.rotation.eulerAngles.z));
				if ((offset_x <= leniency || offset_x >= 180 - leniency) && offset_y <= leniency ) {
					angle_won = true;
				}
			}
		} else {
			float newx = Mathf.LerpAngle (transform.rotation.eulerAngles.x, winning_coords.x, 0.1f);
			float newy = Mathf.LerpAngle (transform.rotation.eulerAngles.y, winning_coords.y, 0.1f);
			float newz = Mathf.LerpAngle (transform.rotation.eulerAngles.z, winning_coords.z, 0.1f);

			transform.eulerAngles = new Vector3(newx, newy, newz);
		}
		if (!pos_won) {
			if (Input.GetMouseButton (mouse_button) && Input.GetKey (KeyCode.LeftShift)) {
				float moveamounty = Input.GetAxis ("Mouse Y") * movespeed * Time.deltaTime;
				transform.position = new Vector3 (transform.position.x, transform.position.y + moveamounty, transform.position.z);
			}
		}

		if (pos_won && angle_won) {
			//Win
		}
	}
}
