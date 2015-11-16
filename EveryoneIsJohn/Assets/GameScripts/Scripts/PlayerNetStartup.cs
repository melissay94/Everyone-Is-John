using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
//[RequireComponent class PlayerController]

public class PlayerNetStartup : NetworkBehaviour
{
	void Start ()
	{
		/*
		 * We turned off the character controller, firstperson controller, 
		 * the main camera and its audiolistener, because only OUR OWN character should respond to 
		 * keyboard events and control the camera, not all the other clients.
		 * 
		 * So here we turn them all back on IF IT'S US. 
		 * */

		if (isLocalPlayer) {
			gameObject.GetComponent<PlayerController> ().enabled = true;

			// Set target to follow this player
			GameObject cam = GameObject.Find("Main Camera");
			cam.GetComponent<cameraFollow>().target = gameObject.transform;
		}
	}
}
