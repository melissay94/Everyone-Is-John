using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator animator;//= GetComponent<Animator> ();
	//animator = this.GetComponent<Animator> ();
	public float speed = 10f;
	public int willpower;
	public Skill skill1;
	public Skill skill2;
	public Skill skill3;
	public Obsession obsession1;
	public Obsession obsession2;
	public Obsession obsession3;

	public Color color;
	public string username;

	public Player () {

	}

	void Start() {
		animator = this.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		PlayerInput ();

	}

	private void PlayerInput() {
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
			animator.SetInteger("Direction", 1);
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			animator.SetInteger("Direction", 0);
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
			animator.SetInteger("Direction", 3);
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			animator.SetInteger("Direction", 2);
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		else {
			animator.SetInteger("Direction", 4);
		}
	}
}
