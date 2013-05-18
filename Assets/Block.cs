using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	
	private bool isBroken;
	
	public bool IsBroken{
		get { return isBroken; }
	}
	
	// Use this for initialization
	void Start () {
		isBroken = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "fist" && isBroken == false) {
			isBroken = true;	
		} 
		
	}
}
