using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace UnityStandardAssets.Network
{
	//Player entry in the lobby. 
	//attached to the PlayerInfo prefab
	//Handles selecting color/setting name & getting ready for the game
	//Any LobbyHook can then grab it and pass those value to the game player prefab 
	//(see the Pong Example in the Samples Scenes)
	public class LobbyPlayer : NetworkLobbyPlayer
	{
		static Color[] Colors = new Color[] {
			Color.red,
			Color.magenta,
			Color.cyan,
			Color.blue,
			Color.green,
			Color.yellow
		};

		public Button colorButton;
		public InputField nameInput;
		public Button readyButton;
		public Button waitingPlayerButton;

		//OnMyName function will be invoked on clients when server changes the value of playerName
		[SyncVar(hook = "OnMyName")]
		public string
			playerName = ""; 

		[SyncVar(hook = "OnMyColor")]
		public Color
			playerColor = Color.white;

		static Color JoinColor = new Color (1.0f, 0.0f, 0.0f, 1.0f);
		static Color NotReadyColor = new Color (0.15f, 0.2f, 0.25f, 1.0f);
		static Color ReadyColor = new Color (0.0f, 0.8f, 0.8f, 1.0f);
		static Color TransparentColor = new Color (0, 0, 0, 0);

		static Color OtherPlayerColor = new Color (0.9f, 0.9f, 0.9f, 1.0f);
		static Color LocalPlayerColor = new Color (0.7f, 0.7f, 0.7f, 1.0f);


		public override void OnStartClient ()
		{
			//All networkbehaviour base function don't do anything
			//but NetworkLobbyPlayer redefine OnStartClient, so we need to call it here
			base.OnStartClient ();

			//setup the player data on UI. The value are SyncVar so the player
			//will be created with the right value currently on server
			OnMyName (playerName);
			OnMyColor (playerColor);
		}

		public override void OnClientEnterLobby ()
		{
			base.OnClientEnterLobby ();

			LobbyPlayerList._instance.AddPlayer (this);
			Debug.Log ("Client added");
			LobbyPlayerList._instance.DisplayDirectServerWarning (isServer && LobbyManager.s_Singleton.matchMaker == null);

			//if we return from a game, color of text can still be the one for "Ready"
			readyButton.transform.GetChild (0).GetComponent<Text> ().color = Color.white;

			if (isLocalPlayer) {
				SetupLocalPlayer ();
			} else {
				SetupOtherPlayer ();
			}

			//setup the player data on UI. The value are SyncVar so the player
			//will be created with the right value currently on server
			OnMyName (playerName);
			OnMyColor (playerColor);
		}

		void ChangeReadyButtonColor (Color c)
		{
			ColorBlock b = readyButton.colors;
			b.normalColor = c;
			b.pressedColor = c;
			b.highlightedColor = c;
			b.disabledColor = c;
			readyButton.colors = b;
		}

		void SetupOtherPlayer ()
		{
			nameInput.interactable = false;


			GetComponent<Image> ().color = OtherPlayerColor;

			if (playerColor == Color.white)
				CmdColorChange (slot);

			ChangeReadyButtonColor (NotReadyColor);

			readyButton.gameObject.SetActive (false);
			OnClientReady (false);
		}

		void SetupLocalPlayer ()
		{
			nameInput.interactable = true;

			GetComponent<Image> ().color = LocalPlayerColor;

			ChangeReadyButtonColor (JoinColor);

			readyButton.gameObject.SetActive (true);
			readyButton.transform.GetChild (0).GetComponent<Text> ().text = "Join";
			readyButton.interactable = true;
		}

		public override void OnStartLocalPlayer ()
		{
			//if( (isServer && !NetworkServer.active) || (isClient && !LobbyManager.s_Singleton.client.isConnected))
			//{//the server isn't started, rogue player, just delete it
			//    Destroy(gameObject);
			//    return;
			//}

			//have to use child count of player prefab already setup as "this.slot" is not set yet
			if (playerName == "")
				CmdNameChanged ("Player" + LobbyPlayerList._instance.playerListContentTransform.childCount);
			Debug.Log (LobbyPlayerList._instance.playerListContentTransform.childCount);

			//we switch from simple name display to name input
           
			nameInput.onEndEdit.RemoveAllListeners ();
			nameInput.onEndEdit.AddListener (OnNameChanged);

			colorButton.onClick.RemoveAllListeners ();
			colorButton.onClick.AddListener (OnColorClicked);

			readyButton.onClick.RemoveAllListeners ();
			readyButton.onClick.AddListener (OnReadyClicked);

			SetupLocalPlayer ();
		}

		public override void OnClientReady (bool readyState)
		{
			if (readyState) {
				ChangeReadyButtonColor (TransparentColor);

				Text textComponent = readyButton.transform.GetChild (0).GetComponent<Text> ();
				textComponent.text = "READY";
				textComponent.color = ReadyColor;
				readyButton.interactable = isLocalPlayer;
			} else {
				ChangeReadyButtonColor (isLocalPlayer ? JoinColor : NotReadyColor);

				Text textComponent = readyButton.transform.GetChild (0).GetComponent<Text> ();
				textComponent.text = isLocalPlayer ? "JOIN" : "...";
				textComponent.color = Color.white;
				readyButton.interactable = isLocalPlayer;
			}
		}

		///===== callback from sync var

		public void OnMyName (string newName)
		{
			playerName = newName;
			//nameDisp.text = playerName;
			nameInput.text = playerName;
		}

		public void OnMyColor (Color newColor)
		{
			playerColor = newColor;
			colorButton.GetComponent<Image> ().color = newColor;
		}

		//===== UI Handlers

		//Note these handlers use the Command function, as we need 
		//to change the value on the server, not just locally
		//so that all clients get the new value through syncvar
		public void OnColorClicked ()
		{
			int idx = System.Array.IndexOf (Colors, this.playerColor);

			if (idx < 0)
				idx = 0;

			idx = (idx + 1) % Colors.Length;

			CmdColorChange (idx);
		}

		public void OnReadyClicked ()
		{
			SendReadyToBeginMessage ();
		}

		public void OnNameChanged (string str)
		{
			CmdNameChanged (str);
		}

		//====== Client RPC
		public void RpcToggleJoinButton (bool enabled)
		{
			Debug.Log ("RpcToggleJoinButton " + enabled);
			readyButton.gameObject.SetActive (enabled);
			waitingPlayerButton.gameObject.SetActive (!enabled);
		}

		//====== Server Command

		[Command]
		public void CmdColorChange (int idx)
		{
			playerColor = Colors [idx];
		}

		[Command]
		public void CmdNameChanged (string name)
		{
			playerName = name;
		}
	}
}
