using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JohnNetwork : NetworkManager {

	// Name for game and rooms in game
	private const string serverName = "EveryoneIsJohn2015";
	private const string gameName = "JohnsRoom";

	// Holds host data from master server
	private HostData[] hostInfo;

	// Assign start game button
	Button hostButton;
	Text joinList;
	Button refreshButton;

	// Starts the server with 4 players and a port number
	private void StartServer() {
		Network.InitializeServer (4, 25000, !Network.HavePublicAddress ());
		MasterServer.RegisterHost (serverName, gameName);
		Application.LoadLevel (1);
	}
	
	// Checks to make sure the host information has been receieved
	private void RefreshHostInfo() {
		MasterServer.RequestHostList (serverName);
	}

	// Joins player client to the server
	private void JoinServer(HostData host) {
		Network.Connect (host);
		Application.LoadLevel (1);
	}

	// Initializes Server if possible
	void OnServerInitialized() {
		Debug.Log ("Successful Server");
	}


	// Behaviors for the GUI objects
	void OnGUI() {
		// Create all the login buttons
		hostButton = GameObject.Find("HostButton").GetComponent<Button>();
		joinList = GameObject.Find ("Games Available").GetComponent<Text> ();
		refreshButton = GameObject.Find ("RefreshButton").GetComponent<Button> ();

		// Default all the buttons to no listeners
		hostButton.onClick.RemoveAllListeners();
		refreshButton.onClick.RemoveAllListeners ();

		// Add methods to all the buttons
		hostButton.onClick.AddListener (StartServer);
		refreshButton.onClick.AddListener (RefreshHostInfo);

		if (Network.isClient || Network.isServer) {
			hostButton.enabled = false;
			hostButton.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
			hostButton.GetComponentInChildren<Text>().color = Color.clear;
		}

		if (hostInfo != null && !Network.isServer) {
			joinList.text = "Games Available: " + hostInfo.Length;

			for (int i = 0; i < hostInfo.Length; i++) {
				if (GUI.Button(new Rect(joinList.transform.position.x - 100, joinList.transform.position.y + (150 * (i + 1)), 200, 50), hostInfo[i].gameName + " " + (i + 1))) {
					JoinServer(hostInfo[i]);	
				}
			}
		}
	}

	// Once triggered, stores the host information
	void OnMasterServerEvent(MasterServerEvent msEv) {
		if (msEv == MasterServerEvent.HostListReceived) {
			hostInfo = MasterServer.PollHostList();
		}
	}

	//Called once player joins the server
	void OnConnectedToServer() {
		Debug.Log ("Server joined");
	}

}
