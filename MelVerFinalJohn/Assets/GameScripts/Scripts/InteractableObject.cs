using UnityEngine;
using System.Collections;

public class InteractableObject : MonoBehaviour {
	
	public int type;
	string desc;
	public Action[] actions;

	// Use this for initialization
	void Start () {

		switch (type) {
		
		case 0:
			desc = "Tree";
			actions = new Action[6];
			for (int i = 0; i < actions.Length; i++) {
				actions[i] = new Action(i);
			}
			break;
		case 1:
			desc = "NPC";
			actions = new Action[7];
			for (int i = 0; i < actions.Length; i++) {
				actions[i] = new Action(6+i);
			}
			break;
		case 2:
			desc = "House";
			actions = new Action[11];
			for (int i = 0; i < actions.Length; i++) {
				actions[i] = new Action(13+i);
			}
			break;
		}
	}
}
