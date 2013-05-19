using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
		
	// background image that is 256 x 32
	public Texture2D bgImage; 

	// foreground image that is 256 x 32
	public Texture2D fgImage; 
	
	Hero hero;
	Benedict benedict;

	// an int between 0 and 100
	public int luck;
	public int points;
	

	// Use this for initialization
	void Start () {
		/*if (GameObject.Find("Hero") != null) {
			hero = GameObject.Find("Hero").GetComponent<Hero>();
			if (hero == null)
				print ("hero is null... what is this? " + GameObject.Find("Hero") + " and what is this...? " + GameObject.Find("Hero").GetComponent<Hero>());
		} else {
			print ("ERROR");
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		//points = hero.GetPoints;
		// luck = benedict.GetLuck;
	}
	
	void OnGUI() {
		float width  = Camera.main.pixelWidth;
		float height = Camera.main.pixelHeight;
			
		// Timer and Points
		// Make a group on the center of the screen
		GUI.BeginGroup (new Rect (width - 110, 10, 150, 50));

		// We'll make a box so you can see where the group is on-screen.
		
		GUI.Box (new Rect (0,0,100,100), string.Format ("Time: {0:0}:{1:00}", Mathf.Floor (Time.time/60), Time.time % 60));

		// Add conditional here: if on hero run
		GUI.Box (new Rect (0,25,100,100), string.Format ("Points: {0}", points));

		// End the group we started above. This is very important to remember!
		GUI.EndGroup ();
		
		
		// Luck meter if on Benedict (prob needs repositioning)
		// Adjust the first 2 coordinates to place it somewhere else on-screen
		GUI.BeginGroup (new Rect (0,0,256,32));

		// Draw the background image
		GUI.Box (new Rect (0,0,256,32), bgImage);

			// Create a second Group which will be clipped
			// We want to clip the image and not scale it, which is why we need the second Group
			GUI.BeginGroup (new Rect (0,0, luck * 2.56f, 32));

			// Draw the foreground image
			GUI.Box (new Rect (0,0,256,32), fgImage);

			// End both Groups
			GUI.EndGroup ();

		GUI.EndGroup ();
    }
}
