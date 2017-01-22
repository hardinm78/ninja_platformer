using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject target;

	private Vector3 offset;
	private bool facingRight;
	// Use this for initialization
	void Start () {
		offset = new Vector3 (5f, 2f, -10f);
		print (offset);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis("Horizontal")>0){
			offset = new Vector3 (5f, 2f, -10f);
		}else if (Input.GetAxis("Horizontal")<0){
			offset = new Vector3 (-5f, 2f, -10f);
		}
		transform.position = Vector3.Lerp (transform.position, target.transform.position + offset, Time.deltaTime * 3f);
	}
}
