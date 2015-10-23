using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 10f;
	public int willpower;
	public Skill skill1;
	public Skill skill2;
	public Skill skill3;
	public Obsession obsession;

	public Player () {
		willpower = 10;
	}

	// Update is called once per frame
	void Update () {

		if (Network.isServer) {
			PlayerInput();
		}

	}

	private void PlayerInput() {
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
	}
}
