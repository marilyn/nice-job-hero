using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public GameObject player;
	public float snapWidth;
	public float snapHeight;
	
	bool didReplay = false;
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(player != null){
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
	
	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape) && !didReplay){
			Replay();	
		}
	}
	
	void Replay(){
		didReplay = true;
		player.GetComponent<Player>().Cancel();
		InvokeRepeating("playerReplay", 0, .005f);
	}
	
	int i = 0;
	void playerReplay(){
		if(i<player.GetComponent<Player>().posInTime.Count){
			player.transform.position = player.GetComponent<Player>().posInTime[i++];
		}
	}
}
