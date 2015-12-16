using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	private bool showMenu = false;
	private InteractableObject obj;
	private int listEntry = 0;
	private GUIContent[] list;
	private GUIStyle listStyle;
	private bool picked = false;

	public void ToggleMenu() {
		showMenu = !showMenu;
	}

	public void SetObj(InteractableObject obj) {
		this.obj = obj;
	}

	// Use this for initialization
	void Start () {
		showMenu = false;

		// Make a GUIStyle that has a solid white hover/onHover background to indicate highlighted items
		listStyle = new GUIStyle();
		listStyle.normal.textColor = Color.white;
		var tex = new Texture2D(2, 2);
		listStyle.hover.background = tex;
		listStyle.onHover.background = tex;
		listStyle.padding.left = listStyle.padding.right = listStyle.padding.top = listStyle.padding.bottom = 4;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGui()
	{
		if(showMenu) {
			if (obj != null) {
				// Generate some content for the popup list based on the object you are currently interacting with
				list = new GUIContent[obj.actions.Length];
				for (int i = 0; i < obj.actions.Length; i++) {
					list[i] = new GUIContent(obj.actions[i].GetDesc());
				}
			}
		}
	}

}
