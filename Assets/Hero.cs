using UnityEngine;
using System.Collections;

public class Hero : Player {
	
	private int points;

	// Use this for initialization
	void Start () {
		points = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	new public void acquires(GameObject obj) {
		if (obj.tag == "charm") {
			Charm charm = obj.GetComponent<Charm>();
			points += charm.GetPoints;
		}
	}
}
