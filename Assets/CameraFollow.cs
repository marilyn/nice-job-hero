using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public GameObject player;
	public float width;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(player.transform.position.x > this.transform.position.x+width){
			this.transform.position = new Vector3(player.transform.position.x - width,this.transform.position.y, this.transform.position.z);	
		}
		
		if(player.transform.position.x < this.transform.position.x-width){
			this.transform.position = new Vector3(player.transform.position.x + width,this.transform.position.y, this.transform.position.z);	
		}
	}
}
