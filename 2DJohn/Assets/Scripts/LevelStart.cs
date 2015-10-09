using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LevelStart : MonoBehaviour {

	// Set up disconnect button after attaching to server without constantly installing it. 
	public void SetUpDisconnect() {
		
		if (GameObject.Find ("DisconnectButton") != null) {
			print ("SetupChatSceneButtons");
			GameObject.Find ("DisconnectButton").GetComponent<Button> ().onClick.RemoveAllListeners ();
			GameObject.Find ("DisconnectButton").GetComponent<Button> ().onClick.AddListener (Disconnect);
		}
	}

	private void Disconnect() {

		Network.Disconnect ();
		NetworkManager.singleton.StopHost ();
		Destroy (GameObject.Find ("NetworkObject"));
		
	}

	void Start() {
		SetUpDisconnect ();
	}
}
