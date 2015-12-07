using UnityEngine;
using System.Collections;

public class Skill {

	string desc;
	int type;

	public Skill (int t) {
		type = t;

		switch (t) {
		case 0:
			desc = "Agile";
			break;
		case 1:
			desc = "Good with Fire";
			break;
		case 2:
			desc = "Good with People";
			break;
		case 3:
			desc = "Good with Tools";
			break;
		case 4:
			desc = "Walks fast";
			break;
		}
	}

	public Skill GetSkill (int type) {
		return new Skill(type);
	}
}
