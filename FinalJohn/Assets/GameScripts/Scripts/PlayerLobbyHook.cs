﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.Network;

public class PlayerLobbyHook : LobbyHook {

	public override void OnLobbyServerSceneLoadedForPlayer(UnityEngine.Networking.NetworkManager manager, 
	                                                       GameObject lobbyPlayer, GameObject gamePlayer) 
	{
		LobbyPlayer I = lobbyPlayer.GetComponent<LobbyPlayer> ();
		//PlayerBoard playerB = gamePlayer.GetComponent<PlayerBoard> ();


	}
}
