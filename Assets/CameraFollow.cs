using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public GameObject player;
	public float snapWidth;
	public float snapHeight;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(player.transform.position.x > this.transform.position.x+snapWidth){
			this.transform.position = new Vector3(player.transform.position.x - snapWidth,this.transform.position.y, this.transform.position.z);	
		}
		
		if(player.transform.position.x < this.transform.position.x-snapWidth){
			this.transform.position = new Vector3(player.transform.position.x + snapWidth,this.transform.position.y, this.transform.position.z);	
		}
		
		if(player.transform.position.y > this.transform.position.y+snapHeight){
			this.transform.position = new Vector3(this.transform.position.x ,player.transform.position.y - snapHeight, this.transform.position.z);	
		}
		
		if(player.transform.position.y < this.transform.position.y-snapHeight){
			this.transform.position = new Vector3(this.transform.position.x ,player.transform.position.y + snapHeight, this.transform.position.z);	
		}
	}
}
