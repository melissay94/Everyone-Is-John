using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Types;
using UnityEngine.Networking.Match;
using System.Collections;


namespace UnityStandardAssets.Network
{
	// subclasses the NetworkLobbyManager
	public class LobbyManager : NetworkLobbyManager
	{
		static public LobbyManager s_Singleton;

		public int minPlayers;

		public LobbyTopPanel topPanel;

		public RectTransform mainMenuPanel;
		public RectTransform lobbyPanel;

		public LobbyInfoPanel infoPanel;

		protected RectTransform currentPanel;

		public Button backButton;

		public Text statusInfo;
		public Text hostInfo;

	
		protected UnityStandardAssets.Network.LobbyHook _lobbyHooks;

		void Start ()
		{
			s_Singleton = this;
			_lobbyHooks = GetComponent<UnityStandardAssets.Network.LobbyHook> ();
			currentPanel = mainMenuPanel;

			backButton.gameObject.SetActive (false);
			GetComponent<Canvas> ().enabled = true;

			DontDestroyOnLoad (gameObject);
		}

		public override void OnLobbyClientSceneChanged (NetworkConnection conn)
		{
			if (!conn.playerControllers [0].unetView.isLocalPlayer)
				return;

			if (Application.loadedLevelName == lobbyScene) {
				if (topPanel.isInGame) {
					ChangeTo (lobbyPanel);

					if (conn.playerControllers [0].unetView.isClient) {
						backDelegate = StopHostClbk;
					} else {
						backDelegate = StopClientClbk;
					}
				
				} else { // !isInGame
					ChangeTo (mainMenuPanel);
				}

				topPanel.ToggleVisibility (true);
				topPanel.isInGame = false;

			} else { //not lobbyScene
				ChangeTo (null);

				Destroy (GameObject.Find ("MainMenuUI(Clone)"));

				backDelegate = StopGameClbk;
				topPanel.isInGame = true;
				topPanel.ToggleVisibility (false);
			}
		}

		public void ChangeTo (RectTransform newPanel)
		{
			if (currentPanel != null) {
				currentPanel.gameObject.SetActive (false);
			}

			if (newPanel != null) {
				newPanel.gameObject.SetActive (true);
			}

			currentPanel = newPanel;

			if (currentPanel != mainMenuPanel) {
				backButton.gameObject.SetActive (true);
			} else {
				backButton.gameObject.SetActive (false);
				SetServerInfo ("Offline", "None");
			}
		}

		public void DisplayIsConnecting ()
		{
			var _this = this;
			infoPanel.Display ("Connecting...", "Cancel", () => {
				_this.backDelegate (); });
		}

		public void SetServerInfo (string status, string host)
		{
			statusInfo.text = status;
			hostInfo.text = host;
		}

		//set up delegate for back button
		//needs to do different things in different circumstances
		public delegate void BackButtonDelegate ();
		public BackButtonDelegate backDelegate;
		public void GoBackButton ()
		{
			backDelegate ();
		}

		// ----------------- Server management

		public void SimpleBackClbk ()
		{
			ChangeTo (mainMenuPanel);
		}

		public void StopHostClbk ()
		{
			StopHost ();
 
			ChangeTo (mainMenuPanel);
		}

		public void StopClientClbk ()
		{
			StopClient ();

			ChangeTo (mainMenuPanel);
		}

		public void StopServerClbk ()
		{
			StopServer ();
			ChangeTo (mainMenuPanel);
		}

		public void StopGameClbk ()
		{
			SendReturnToLobby ();
			ChangeTo (lobbyPanel);
		}

		//===================

		public override void OnStartHost ()
		{
			base.OnStartHost ();

			ChangeTo (lobbyPanel);
			backDelegate = StopHostClbk;
			SetServerInfo ("Hosting", networkAddress);
		}

		public override void OnClientConnect (NetworkConnection conn)
		{
			base.OnClientConnect (conn);

			infoPanel.gameObject.SetActive (false);

			if (!NetworkServer.active) {//only for pure client (not self hosting client)
				ChangeTo (lobbyPanel);
				backDelegate = StopClientClbk;
				SetServerInfo ("Client", networkAddress);
			}
		}

		// ----------------- Server callbacks ------------------

		//we want to disable the button JOIN if we don't have enough players
		//But OnLobbyClientConnect isn't called on hosting player. So we override the lobbyPlayer creation
		public override GameObject OnLobbyServerCreateLobbyPlayer (NetworkConnection conn, short playerControllerId)
		{
			GameObject obj = Instantiate (lobbyPlayerPrefab.gameObject) as GameObject;

			LobbyPlayer newPlayer = obj.GetComponent<LobbyPlayer> ();
			//numPlayers is in NetworkManager
			newPlayer.RpcToggleJoinButton (numPlayers > 0 && numPlayers <= minPlayers);

			for (int i = 0; i < numPlayers; ++i) {
				LobbyPlayer p = lobbySlots [i] as LobbyPlayer;

				if (p != null) {
					p.RpcToggleJoinButton (numPlayers + 1 >= minPlayers);
				}
			}

			return obj;
		}

		public override void OnLobbyServerDisconnect (NetworkConnection conn)
		{
			for (int i = 0; i < numPlayers; ++i) {
				LobbyPlayer p = lobbySlots [i] as LobbyPlayer;

				if (p != null) {
					p.RpcToggleJoinButton (numPlayers >= minPlayers);
				}
			}

		}

		public override bool OnLobbyServerSceneLoadedForPlayer (GameObject lobbyPlayer, GameObject gamePlayer)
		{
			//This hook allows you to apply state data from the lobby-player to the game-player
			//just subclass "LobbyHook" and add it to the lobby object.

			if (_lobbyHooks)
				_lobbyHooks.OnLobbyServerSceneLoadedForPlayer (this, lobbyPlayer, gamePlayer);

			return true;
		}

		// ----------------- Client callbacks ------------------

		public override void OnClientDisconnect (NetworkConnection conn)
		{
			base.OnClientDisconnect (conn);
			ChangeTo (mainMenuPanel);
		}

		public override void OnClientError (NetworkConnection conn, int errorCode)
		{
			ChangeTo (mainMenuPanel);
			infoPanel.Display ("Client error : " + (errorCode == 6 ? "timeout" : errorCode.ToString ()), "Close", null);
		}
	}
}
