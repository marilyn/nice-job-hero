using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
		
	Hero hero;
	Benedict benedict;

	// an int between 0 and 100
	public int luck;
	public int points;
	public float health;
	

	// Use this for initialization
	void Start () {
		if (GameObject.Find("Hero") != null) {
			hero = GameObject.Find("Hero").GetComponent<Hero>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		points = hero.GetPoints;
    	health = hero.Health;
	}
	
	void OnGUI() {
		
		if(!Camera.main.GetComponent<GameManager>().screenGO.activeSelf){
			float width  = Camera.main.pixelWidth;
			float height = Camera.main.pixelHeight;
				
			// Timer and Points
			// Make a group on the center of the screen
			if (hero != null && hero.gameObject.activeSelf)
				GUI.BeginGroup (new Rect (width - 110, 10, 150, 75));
			else
				GUI.BeginGroup (new Rect (width - 110, 10, 150, 50));

			// We'll make a box so you can see where the group is on-screen.
			
			GUI.Box (new Rect (0,0,100,100), string.Format ("Time: {0:0}:{1:00}", Mathf.Floor (Time.time/60), Time.time % 60));

			if (hero != null && hero.gameObject.activeSelf) {
				GUI.Box (new Rect (0,25,100,100), string.Format ("Points: {0}", points));
				GUI.Box (new Rect (0,50,100,100), string.Format ("Health: {0}", Mathf.Floor (health)));
			}
			else 
				GUI.Box (new Rect (0,25,100,100), string.Format ("Luck: {0}", luck));

			// End the group we started above. This is very important to remember!
			GUI.EndGroup ();
		}
    }
}
