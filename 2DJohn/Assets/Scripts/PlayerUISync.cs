using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections.Generic;


public class PlayerUISync : NetworkBehaviour {

	
	[SyncVar(hook = "SyncScore")]
	private int
		syncScore;
	
	private Text ScoreText;
	public int score;

	[SyncVar(hook = "SyncWillpower")]
	private int
		syncWillpower;
	
	private Text WillpowerText;
	public int willpower;
	
	void Start()
	{
		ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		WillpowerText = GameObject.Find("WillpowerText").GetComponent<Text>();

		TransmitScore();
	}
	
	void Update()
	{
		// Update the server
		if (!isLocalPlayer)
		{
			// willpower will go here
			// Score is hidden from other players
		}
	}
	
	void FixedUpdate()
	{
		TransmitScore();
		TransmitWP ();
	}
	
	//Score 
	
	[Command]
	void CmdSendScoreToServer(int s)
	{
		//runs on server, we call on client
		syncScore = s;
	}
	
	[Client]
	void TransmitScore()
	{
		// This is where we (the client) send out our position.
		if (isLocalPlayer)
		{
			ScoreText.text = "Score: " + score;
			CmdSendScoreToServer(score);
		}
	}
	
	[Client]
	void SyncScore(int score)
	{
		syncScore = score;
	}

	//Willpower 
	
	[Command]
	void CmdSendWPToServer(int wp)
	{
		//runs on server, we call on client
		syncWillpower = wp;
	}
	
	[Client]
	void TransmitWP()
	{
		// This is where we (the client) send out our position.
		if (isLocalPlayer)
		{
			WillpowerText.text = "WP: " + willpower;
			CmdSendWPToServer(willpower);
		}
	}
	
	[Client]
	void SyncWP(int willpower)
	{
		syncWillpower = willpower;
	}
}
