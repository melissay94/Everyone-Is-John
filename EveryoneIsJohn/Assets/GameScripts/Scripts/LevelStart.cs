using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LevelStart : MonoBehaviour {

	private Image pauseImage;
	private Button pauseButton;

	void Start() {
		pauseImage = GameObject.Find ("Pause Menu").GetComponent<Image>();
		pauseButton = GameObject.Find ("BackToGame").GetComponent<Button> ();
		pauseImage.gameObject.SetActive (false);
		pauseButton.gameObject.SetActive (false);
	}

	public void Disconnect() {

		Network.Disconnect ();
		NetworkManager.singleton.StopHost ();
		Destroy (GameObject.Find ("NetworkObject"));
		
	}

	public void PauseGame() {

		pauseImage.gameObject.SetActive (true);
		pauseButton.gameObject.SetActive (true);
	}

	public void BackToGame() {
		pauseImage.gameObject.SetActive (false);
		pauseButton.gameObject.SetActive (false);
	}
}
