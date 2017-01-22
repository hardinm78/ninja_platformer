using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


	public float speed = 5f;
	public float jumpForce = 10f;

	private Animator anim;
	private Rigidbody2D rigi;
	private bool canJump;
	private bool facingRight = true;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rigi = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("Horizontal") > 0) {
			if (!facingRight) {
				transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
				facingRight = true;
			}
			transform.position += Vector3.right * speed * Time.deltaTime;
			anim.SetBool ("isRunning", true);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			if (facingRight) {
				transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
				facingRight = false;
			}
			transform.position += Vector3.left * speed * Time.deltaTime;
			anim.SetBool ("isRunning", true);
		} else {
			anim.SetBool ("isRunning", false);
		}


		if (Input.GetButtonDown ("Jump")) {
			if (canJump) {
				rigi.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
				anim.SetTrigger ("jumping");
				canJump = false;
			}
		}


		if (Input.GetButtonDown ("Fire1")) {
				anim.SetTrigger ("attacking");
			}
		}
		


	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Ground") {
			canJump = true;
		}
	}

}
