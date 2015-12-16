using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PopulatePlayerChoice : MonoBehaviour {
	
	public RectTransform skillPanel;
	public RectTransform obsessionPanel;
	public Texture2D buttonTexture;

	private string[] skillList;
	private string[] obsessionList;

	public List<string> playerChosenSkills;
	public List<string> playerChosenObsessions;

	// Button and Text generation code from http://chikkooos.blogspot.com/2015/03/new-ui-implementation-using-c-scripts.html tutorial
	private GameObject GenerateButton(Transform parent, float x, float y, float width, float height, string label) {

		// Creates buttons
		GameObject listButton = new GameObject("Button");
		listButton.transform.parent = parent.transform;
		RectTransform bTrans = listButton.AddComponent<RectTransform> ();
		bTrans.sizeDelta = new Vector2 (width, height);
		bTrans.position = new Vector3 (x, y);
		listButton.AddComponent<CanvasRenderer> ();
		Image image = listButton.AddComponent<Image> ();
		Texture2D tex = buttonTexture;
		image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
		Button button = listButton.AddComponent<Button> ();
		button.interactable = true;
		
		GameObject buttonText = GenerateText (listButton.transform, 0, 0, 0, 0, label, 25);
		ColorBlock buttonColor = button.colors;

		// Adds listener to buttons to check if they've been selected or not.
		bool isActive = false;
		button.onClick.AddListener (delegate {
			if ( isActive == false) 
				isActive = playerListsPopulator(label, listButton);
			else if (isActive == true)
				isActive = playerListSubtract(label, listButton);
		});
		
		return listButton;
	}

	// Creates text to add to buttons
	private GameObject GenerateText(Transform parent, float x, float y, float w, float h, string message, int fontSize) {
		
		GameObject textObject = new GameObject("Text");
		textObject.transform.SetParent(parent);
		RectTransform trans = textObject.AddComponent<RectTransform>();
		trans.sizeDelta.Set(w, h);
		trans.anchoredPosition3D = new Vector3(0, 0, 0);
		trans.anchoredPosition = new Vector2(x, y);
		trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		trans.localPosition.Set(0, 0, 0);
		
		CanvasRenderer renderer = textObject.AddComponent<CanvasRenderer>();
		
		Text text = textObject.AddComponent<Text>();
		text.supportRichText = true;
		text.text = message;
		text.fontSize = fontSize;
		text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.alignment = TextAnchor.MiddleCenter;
		text.horizontalOverflow = HorizontalWrapMode.Overflow;
		text.color = new Color(0, 0, 0);
		
		return textObject;
	}

	// Generates all five skills to the panel
	private void PopulateSkillPanel(string[] skills) {
		
		float buttonWidth = skillPanel.rect.width - 20;
		float buttonHeight = skillPanel.rect.height/6;
		float buttonPositionx = skillPanel.position.x;
		float buttonPositiony = skillPanel.position.y + skillPanel.rect.height / 2 - buttonHeight/2;
		
		for (int i = 0; i < skills.Length; i++) {
			GenerateButton (skillPanel, buttonPositionx, buttonPositiony, buttonWidth, buttonHeight, skills[i]);
			buttonPositiony -= buttonHeight;
			buttonPositiony -= 10;
		}
	}

	private void PopulateObsessionPanel(string[] obsession) {

		//Makes five buttons based on the random numbers
		float buttonWidth = obsessionPanel.rect.width - 20;
		float buttonHeight = obsessionPanel.rect.height/6;
		float buttonPositionx = obsessionPanel.position.x;
		float buttonPositiony = obsessionPanel.position.y + obsessionPanel.rect.height / 2 - buttonHeight/2;

		// Place to store random numbers
		List<int> randomNumbers = new List<int> ();

		// Generates 5 different random numbers
		while (randomNumbers.Count < 5) {
			int myRandom = Random.Range (0, obsession.Length - 1);
			if (!randomNumbers.Contains(myRandom)) {
				randomNumbers.Add (myRandom);
				GenerateButton (obsessionPanel, buttonPositionx, buttonPositiony, buttonWidth, buttonHeight, obsession[myRandom]);
				buttonPositiony -= buttonHeight;
				buttonPositiony -= 10;
			}
		}
	}

	// Check for what type of button was clicked
	private bool playerListsPopulator(string label, GameObject listButton) {
		for (int i = 0; i < obsessionList.Length; i++) {
			if (label == obsessionList[i] && playerChosenObsessions.Count < 3 ) {
				playerChosenObsessions.Add(label);
				listButton.GetComponent<Image>().color = Color.red;
				break;
			}
			if (i < skillList.Length && playerChosenSkills.Count < 3) {
				if(label == skillList[i]) {
					playerChosenSkills.Add(label);
					listButton.GetComponent<Image>().color = Color.red;
					break;
				}
			}
		}
		return true;
	}

	// If a player deselects an item, it's taken from that list
	private bool playerListSubtract(string label, GameObject listButton) {
		for (int i = 0; i < obsessionList.Length; i++) {
			if (label == obsessionList[i]) {
				playerChosenObsessions.Remove(label);
				break;
			}
			if (i < skillList.Length && label == skillList[i]) {
				playerChosenSkills.Remove(label);
				break;
			}	
		}
		listButton.GetComponent<Image>().color = Color.white;
		return false;
	}

	void Start() {

		// Instatiate and populate panels
		skillList = new string[]{"Agile", "Good with Fire", "Good with People", "Good with Tools", "Walks fast"};
		obsessionList = new string[]{"Climb a tree", "Fight a person", "Parkour", "Burn a Tree", "Burn a Person", 
			"Burn a House", "Help Someone", "Make a Friend", "Get a Job", "Chop a Treee", "Paint a house", "Build a Tree House" };
		PopulateSkillPanel (skillList);
		PopulateObsessionPanel (obsessionList);

		// Instantiate player choice lists
		playerChosenSkills = new List<string> ();
		playerChosenObsessions = new List<string> ();
		
	}
}
