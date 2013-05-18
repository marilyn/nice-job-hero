using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		float width  = Camera.main.pixelWidth;
		float height = Camera.main.pixelHeight;
				
		// Make a group on the center of the screen
		GUI.BeginGroup (new Rect (width - 110, 10, 150, 25));

		// We'll make a box so you can see where the group is on-screen.
		GUI.Box (new Rect (0,0,100,100), string.Format ("Time: {0:0}:{1:00}", Mathf.Floor (Time.time/60), Time.time % 60));

		// End the group we started above. This is very important to remember!
		GUI.EndGroup ();
    }
}
