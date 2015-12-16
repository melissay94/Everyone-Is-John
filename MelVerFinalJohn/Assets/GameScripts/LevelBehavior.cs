using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityStandardAssets.Network;

public class LevelBehavior : NetworkBehaviour {

	private Image pauseImage;
	private Button backToButton;

	[SyncVar]
	public bool GameRunning;

	static public Player[] JohnPlayers = new Player[2];

	public void BackToGame(){

		pauseImage = GameObject.Find ("Pause Menu").GetComponent<Image> ();
		pauseImage.gameObject.SetActive (false);

		backToButton = GameObject.Find ("BackToGame").GetComponent<Button> ();
		backToButton.gameObject.SetActive (false);
	}

	void Start() {

		//JohnPlayers [1].enabled = false;
	}
}
