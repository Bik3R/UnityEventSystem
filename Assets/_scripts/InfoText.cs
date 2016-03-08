using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoText : MonoBehaviour {

	public GazeInputModule inputModule;

	// Use this for initialization
	void Start () {
		string txt;

		if (inputModule._mode == GazeInputModule.Mode.Click) {
			txt = "You are in Click Mode. Press SPACE/ENTER to click!";
		} else {
			txt = "You are in Gaze Mode. Look at an object for " + inputModule.GazeTime + " seconds to click!";
		}
		GetComponent<Text> ().text = txt;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
