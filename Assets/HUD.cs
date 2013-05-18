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
		GUI.BeginGroup (new Rect (width - 110, 10, 150, 100));
		// All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

		// We'll make a box so you can see where the group is on-screen.
		GUI.Box (new Rect (0,0,100,100), string.Format ("Group is here {0}", Time.time.ToString("#")));
		GUI.Button (new Rect (10,40,80,30), "Click me");

		// End the group we started above. This is very important to remember!
		GUI.EndGroup ();
        
    }
}
