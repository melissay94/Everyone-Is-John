using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Network;

public class StartButtons : MonoBehaviour {

	public RectTransform startPanel;
	public RectTransform aboutPanel;
	public RectTransform creditsPanel;
	public RectTransform howToPanel;
	public Button backButton;
	
	public void NextScreen() {
		Application.LoadLevel (1);
	}

	public void AboutInfo(){
		startPanel.gameObject.SetActive (false);
		aboutPanel.gameObject.SetActive (true);
		backButton.enabled = true;
		backButton.gameObject.SetActive (true);
	}

	public void CreditsInfo(){
		startPanel.gameObject.SetActive (false);
		creditsPanel.gameObject.SetActive (true);
		backButton.enabled = true;
		backButton.gameObject.SetActive (true);
	}

	public void HowToPlayInfo() {
		startPanel.gameObject.SetActive (false);
		howToPanel.gameObject.SetActive (true);
		backButton.enabled = true;
		backButton.gameObject.SetActive (true);
	}

	public void GoBack(){
		if (aboutPanel.gameObject.activeInHierarchy == true) {
			startPanel.gameObject.SetActive (true);
			aboutPanel.gameObject.SetActive (false);
			backButton.enabled = false;
			backButton.gameObject.SetActive (false);
		} 
		else if (creditsPanel.gameObject.activeInHierarchy == true) {
			startPanel.gameObject.SetActive (true);
			creditsPanel.gameObject.SetActive (false);
			backButton.enabled = false;
			backButton.gameObject.SetActive (false);
		} 
		else if (howToPanel.gameObject.activeInHierarchy == true) {
			startPanel.gameObject.SetActive (true);
			howToPanel.gameObject.SetActive (false);
			backButton.enabled = false;
			backButton.gameObject.SetActive (false);
		}
	}

	void Start() {
		backButton.enabled = false;
		backButton.gameObject.SetActive (false);
	}
}
