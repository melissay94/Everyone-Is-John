using UnityEngine;
using System.Collections;

public class Obsession {

	string desc;
	Skill skill;
	int level;
	int type;

	public Obsession (int t) {
		
		type = t;

		switch (t) {
		case 0:
			desc = "Climb a Tree";
			level = 1;
			skill = new Skill(0);
			break;
		case 1:
			desc = "Fight a Person";
			level = 2;
			skill = new Skill(0);
			break;
		case 2:
			desc = "Parkour";
			level = 3;
			skill = new Skill(0);
			break;
		case 3:
			desc = "Burn a Tree";
			level = 1;
			skill = new Skill(1);
			break;
		case 4:
			desc = "Burn a Person";
			level = 2;
			skill = new Skill(1);
			break;
		case 5:
			desc = "Burn a House";
			level = 3;
			skill = new Skill(1);
			break;
		case 6:
			desc = "Help someone";
			level = 1;
			skill = new Skill(2);
			break;
		case 7:
			desc = "Make a Friend";
			level = 2;
			skill = new Skill(2);
			break;
		case 8:
			desc = "Get a Job";
			level = 3;
			skill = new Skill(2);
			break;
		case 9:
			desc = "Chop a Tree";
			level = 1;
			skill = new Skill(3);
			break;
		case 10:
			desc = "Paint a House";
			level = 2;
			skill = new Skill(3);
			break;
		case 11:
			desc = "Build a Tree House";
			level = 3;
			skill = new Skill(3);
			break;
		}
	}

	public Obsession GetObsession (int type) {
		return new Obsession(type);
	}
}
