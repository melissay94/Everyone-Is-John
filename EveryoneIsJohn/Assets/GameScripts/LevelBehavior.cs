using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelBehavior : MonoBehaviour {

	private Image pauseImage;
	private Button backToButton;

	public void BackToGame(){

		pauseImage = GameObject.Find ("Pause Menu").GetComponent<Image> ();
		pauseImage.gameObject.SetActive (false);

		backToButton = GameObject.Find ("BackToGame").GetComponent<Button> ();
		backToButton.gameObject.SetActive (false);
	}
}
