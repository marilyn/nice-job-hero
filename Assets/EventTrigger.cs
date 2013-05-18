using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventTrigger : MonoBehaviour {
	
	public List<Vector3> posInEvent = new List<Vector3>();
	bool recordEvent = false;
	
	GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col){
		if(col.tag == "hero" && !recordEvent){
			recordEvent = true;
			player = col.gameObject;
			InvokeRepeating("RecordEvent" , 0, .002f);
		}
	}
	
	void RecordEvent(){
		if(posInEvent.Count < 1000){
		posInEvent.Add(player.transform.position);
		}
	}
	
	public void Play(){
		CancelInvoke("RecordEvent");
		InvokeRepeating("play", 0, .002f);
	}
	
	int i = 0;
	void play(){
		if(i < posInEvent.Count){
		player.transform.position = posInEvent[i++];
		}
		
	}
}
