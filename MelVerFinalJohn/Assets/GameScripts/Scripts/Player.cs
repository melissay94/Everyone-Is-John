using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public int willpower;
	/*
	public Skill skill1;
	public Skill skill2;
	public Skill skill3;
	public Obsession obsession1;
	public Obsession obsession2;
	public Obsession obsession3;
*/
	public Color color;
	public string username;
	public string skills1;
	public string skills2;
	public string skills3;
	public string obsessions1;
	public string obsessions2;
	public string obsessions3;

	public Text playerNameDisplay;
	public Button playerColorDisplay;
	public Text skillsDisplay1;
	public Text skillsDisplay2;
	public Text skillsDisplay3;
	public Text obsessionsDisplay1;
	public Text obsessionsDisplay2;
	public Text obsessionsDisplay3;

	public Player () {

	}

	void Start() {

		// Set up player name
		playerNameDisplay.text = username;

		// Set up player color
		ColorBlock playerColor = playerColorDisplay.colors;
		playerColor.normalColor = color;
		playerColor.pressedColor = color;
		playerColor.highlightedColor = color;
		playerColor.disabledColor = color;
		playerColorDisplay.colors = playerColor;

		// Set up player skill list
		skillsDisplay1.text = skills1;
		skillsDisplay2.text = skills2;
		skillsDisplay3.text = skills3;

		// Set up player obsession list
		obsessionsDisplay1.text = obsessions1;
		obsessionsDisplay2.text = obsessions2;
		obsessionsDisplay3.text = obsessions3;
	}

}
