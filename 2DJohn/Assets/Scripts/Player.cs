using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 10f;
	public int willpower;
	public int score;
	public Skill skill1;
	public Skill skill2;
	public Skill skill3;
	public Obsession obsession;

	public Player () {
		willpower = 10;
		score = 0;
	}
}
