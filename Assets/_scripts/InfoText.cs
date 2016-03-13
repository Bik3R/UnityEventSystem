using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoText : MonoBehaviour {

	public GazeInputModule inputModule;

	// Use this for initialization
	void Start () {
		string txt;

		if (inputModule._mode == GazeInputModule.Mode.Click) {
			txt = "You are in Click Mode. Press SPACE/ENTER to click!\n";
		} else {
			txt = "You are in Gaze Mode. Look at an object for " + inputModule.GazeTime + " seconds to click!\n";
		}

		txt += "Press C to change cursor mode at any time\n";

		GetComponent<Text> ().text = txt;
	}
	
	void Update() {
		// Handle keypress to change cursor mode
		if (Input.GetKeyUp (KeyCode.C)) {
			if(inputModule._cursorMode == GazeInputModule.CursorMode.Static)
				inputModule._cursorMode = GazeInputModule.CursorMode.Dynamic;
			else
				inputModule._cursorMode = GazeInputModule.CursorMode.Static;
		}
	}
}
