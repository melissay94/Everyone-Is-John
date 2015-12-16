using UnityEngine;
using System.Collections;

public class Action {

	string desc;
	int type;

	public string GetDesc() {
		return desc;
	}

	public Action (int t) {
		
		type = t;
		
		switch (t) {
		
		// Tree
		
		case 0:
			desc = "Climb";
			break;
		case 1:
			desc = "Light"; // Tree
			break;
		case 2:
			desc = "Chop";
			break;
		case 3:
			desc = "Prep";
			break;
		case 4:
			desc = "Walls";
			break;
		case 5:
			desc = "Roof";
			break;

		// NPC

		case 6:
			desc = "Gas"; // Person
			break;
		case 7:
			desc = "Light"; // Person
			break;
		case 8:
			desc = "Anger";
			break;
		case 9:
			desc = "Fight";
			break;
		case 10:
			desc = "Help";
			break;
		case 11:
			desc = "Talk";
			break;
		case 12:
			desc = "Befriend";
			break;
		
		// House
		case 13:
			desc = "Gas"; // House
			break;
		case 14:
			desc = "Light"; // House
			break;
		case 15:
			desc = "Run"; // House
			break;
		case 16:
			desc = "Enter";
			break;
		case 17:
			desc = "Parkour";
			break;
		case 18:
			desc = "Exit";
			break;
		case 19:
			desc = "Prime";
			break;
		case 20:
			desc = "Paint";
			break;
		case 21:
			desc = "Talk"; // Owner
			break;
		case 22:
			desc = "Impress";
			break;
		case 23:
			desc = "Ask for Job";
			break;
		}
	}
	
	public Action GetAction (int type) {
		return new Action(type);
	}
}
