using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Lobby info panel.
/// Display cancel button & other info when connecting
/// </summary>
namespace UnityStandardAssets.Network
{
	public class LobbyInfoPanel : MonoBehaviour
	{
		public Text infoText;
		public Text buttonText;
		public Button singleButton;

		public void Display (string info, string buttonInfo, UnityEngine.Events.UnityAction buttonClbk)
		{
			infoText.text = info;

			buttonText.text = buttonInfo;

			singleButton.onClick.RemoveAllListeners ();

			if (buttonClbk != null) {
				singleButton.onClick.AddListener (buttonClbk);
			}

			//hide this dialog box once you click the button
			singleButton.onClick.AddListener (() => {
				gameObject.SetActive (false); });

			gameObject.SetActive (true);
		}
	}
}