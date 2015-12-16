using UnityEngine;
using System.Collections;
//[RequireComponent class Player]

public class PlayerController : MonoBehaviour {

	float speed;
	private Animator animator;
	// Use this for initialization
	// Update is called once per frame
	void Start() {
		speed = 10f;
		animator = this.GetComponent<Animator> ();
	}
	void Update () {
		
		PlayerInput ();
		
	}
	
	private void PlayerInput() {
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			animator.SetInteger ("Direction", 1);
			transform.position += Vector3.up * speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			animator.SetInteger ("Direction", 0);
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			animator.SetInteger ("Direction", 3);
			transform.position += Vector3.down * speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			animator.SetInteger ("Direction", 2);
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else {

			//animator.setInteger("Direction", 4);
		}
	}

	 void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log ("Is this even being called");
		if (coll.gameObject.name == "npc_0") {

		}
	
	}
}
