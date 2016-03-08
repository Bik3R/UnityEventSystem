using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class GazeInputModule : PointerInputModule {

	public enum Mode { Click = 0, Gaze };
	public Mode _mode;

	[Tooltip("Gaze time in seconds")]
	public float GazeTime = 2f;

	public RaycastResult _curRaycast;

	private PointerEventData mPointerEventData;
	private GameObject mCurrLookAtHandler;
	private float mCurObjGazeTime;

	public override void Process ()
	{
		ProcessLook ();
		ProcessSelect ();
	}

	// Function to process raycasts from center of screen
	void ProcessLook() {
		if (mPointerEventData == null) {
			mPointerEventData = new PointerEventData(eventSystem);
		}

		// Raycast from the center of the screen at all times
		mPointerEventData.position = new Vector2 (Screen.width / 2, Screen.height / 2);
		mPointerEventData.delta = Vector2.zero;

		// Get all raycasts
		List<RaycastResult> rcResults = new List<RaycastResult> ();
		eventSystem.RaycastAll (mPointerEventData, rcResults);

		// We are only interested in the first raycast
		_curRaycast = mPointerEventData.pointerCurrentRaycast = FindFirstRaycast (rcResults);

		ProcessMove (mPointerEventData);
	}

	// Function to process click/gaze on objects
	void ProcessSelect() {

		// Check if we started looking at something
		if (mPointerEventData.pointerEnter != null) {

			// Check if the object we are looking at has changed during movement
			// If so, change the current handler to the new object
			// And update the gaze time for click
			GameObject handler = ExecuteEvents.GetEventHandler<IPointerClickHandler> (mPointerEventData.pointerEnter);

			if (mCurrLookAtHandler != handler) {
				mCurrLookAtHandler = handler;
				mCurObjGazeTime = Time.realtimeSinceStartup + GazeTime;
			}

			// Handle clicks if we have a handler we are looking at
			// A click happens when we have looked at an object for long enough
			// or if we press SPACE while looking at it
			if (mCurrLookAtHandler != null && 
			    (_mode == Mode.Gaze && Time.realtimeSinceStartup > mCurObjGazeTime) ||
				(_mode == Mode.Click && Input.GetButtonDown ("Submit"))) {
				ExecuteEvents.ExecuteHierarchy (mCurrLookAtHandler, mPointerEventData, ExecuteEvents.pointerClickHandler);

				// After click, update the gaze timer
				mCurObjGazeTime = float.MaxValue;
			}

		} else {
			// We are not looking at anything
			mCurrLookAtHandler = null;
		}
	}
}
