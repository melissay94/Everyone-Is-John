using UnityEngine;
using System.Collections;
//[RequireComponent class Player]

public class PlayerController : MonoBehaviour {

	float speed;
	private Animator animator;
	// Use this for initialization
	void Start () {
		speed = gameObject.GetComponent<Player> ().speed;
		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Goes Up
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
			animator.SetInteger("Direction", 1);
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		// Goes Right
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			animator.SetInteger("Direction", 0);
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		// Goes Down
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
			animator.SetInteger("Direction", 3);
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
		//Goes Left
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			animator.SetInteger("Direction", 2);
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
	}
}
