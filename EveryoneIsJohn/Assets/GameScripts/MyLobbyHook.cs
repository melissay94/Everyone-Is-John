using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityStandardAssets.Network;

public class MyLobbyHook : LobbyHook {

	public virtual void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer) 
	{
		gamePlayer.GetComponent<Player>().color = lobbyPlayer.GetComponent<LobbyPlayer>().playerColor;
		gamePlayer.GetComponent<Player>().username = lobbyPlayer.GetComponent<LobbyPlayer>().playerName;

		/*

		gamePlayer.GetComponents<Player>().skill1 = lobbyPlayer.GetComponent<LobbyPlayer>().skill1;
		gamePlayer.GetComponents<Player>().skill2 = lobbyPlayer.GetComponent<LobbyPlayer>().skill2;

		if (false)// third skill selected)
		{
			gamePlayer.GetComponents<Player>().skill3 = lobbyPlayer.GetComponent<LobbyPlayer>().skill3;
			gamePlayer.GetComponents<Player>().willpower = 7;
		} else {
			gamePlayer.GetComponents<Player>().willpower = 10;
		}

		gamePlayer.GetComponents<Player>().obsession1 = lobbyPlayer.GetComponent<LobbyPlayer>().obsession1;
		gamePlayer.GetComponents<Player>().obsession2 = lobbyPlayer.GetComponent<LobbyPlayer>().obsession2;
		gamePlayer.GetComponents<Player>().obsession3 = lobbyPlayer.GetComponent<LobbyPlayer>().obsession3;
		
		//*/
	}

}