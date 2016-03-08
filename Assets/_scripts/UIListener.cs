using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIListener : MonoBehaviour {

	public Text infoText;

	public void UIOnClick(GameObject go) {
		Text text = go.GetComponentInChildren<Text>();
		infoText.text = "Clicked " + (text != null ? text.text : go.name);
		Debug.Log (infoText.text);
	}
}
