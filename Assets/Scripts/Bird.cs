using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	public float upForce = 200f;

	private bool isDead = false;
	private Rigidbody2D rb2d;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (isDead == false) {

			// if player has left-clicked
			if (Input.GetMouseButtonDown(0)) {

				// set velocity to zero for consistent jump behavior
				// add upforce on every tap
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce(new Vector2(0, upForce));
				anim.SetTrigger("Flap");
			}
		}
	}

	// Function from Unity's API
	void OnCollisionEnter2D() {
		isDead = true;
		anim.SetTrigger("Die");
	}
}
