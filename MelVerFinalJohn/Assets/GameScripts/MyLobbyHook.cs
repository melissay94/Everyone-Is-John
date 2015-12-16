using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityStandardAssets.Network;

public class MyLobbyHook : LobbyHook {

	public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer) 
	{
		gamePlayer.GetComponent<Player>().color = lobbyPlayer.GetComponent<LobbyPlayer>().playerColor;
		gamePlayer.GetComponent<Player>().username = lobbyPlayer.GetComponent<LobbyPlayer>().playerName;

		// Other players aren't supposed to see this information, so we don't have to sync it
		PopulatePlayerChoice listsObject = GetComponent<PopulatePlayerChoice> ();

		// Hook up the skills 
		gamePlayer.GetComponent<Player> ().skills1 = listsObject.playerChosenSkills [0];
		gamePlayer.GetComponent<Player> ().skills2 = listsObject.playerChosenSkills [1];
		gamePlayer.GetComponent<Player> ().skills3 = listsObject.playerChosenSkills [2];

		// Hook up the obsessions.
		gamePlayer.GetComponent<Player> ().obsessions1 = listsObject.playerChosenObsessions[0];
		gamePlayer.GetComponent<Player> ().obsessions2 = listsObject.playerChosenObsessions [1];
		gamePlayer.GetComponent<Player> ().obsessions3 = listsObject.playerChosenObsessions [2];
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