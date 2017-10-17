using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_pos : MonoBehaviour {

	// Use this for initialization
	public GameObject obj_1;
	public GameObject obj_2;

	public float leniency;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float pos1 = obj_1.transform.position.y;
		float pos2 = obj_2.transform.position.y;

		float distance = Mathf.Abs (pos2 - pos1);

		if (distance <= leniency && obj_1.GetComponent<rotation_hard>().angle_won && obj_2.GetComponent<rotation_hard>().angle_won) {
			obj_1.GetComponent<rotation_hard> ().pos_won = true;
			obj_2.GetComponent<rotation_hard> ().pos_won = true;
		}
	}
}
