using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class objHandler : MonoBehaviour {

	public Text infoText;

	public void ObjPointerEnter() {
		infoText.text = "Entered " + gameObject.name;
		GetComponent<Renderer> ().material.color = new Color (Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f));
	}

	public void ObjPointerExit() {
		infoText.text = "Exited " + gameObject.name;
		GetComponent<Renderer> ().material.color = Color.white;
	}

	public void ObjPointerClick() {
		infoText.text = "Clicked " + gameObject.name;
	}
}
