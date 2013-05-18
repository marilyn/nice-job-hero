using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventTrigger : MonoBehaviour {
	
	public List<Vector3> posInEvent = new List<Vector3>();
	
	GameObject player;
	
	public bool isTriggered = false;
	public bool isRecording = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter(Collider col){
		if(col.tag == "hero" && !isTriggered){
			isTriggered = true;
			player = col.gameObject;
			
		}
	}
	
	public void RecordEvent(){
		isRecording = true;
		InvokeRepeating("recordEvent" , 0, .005f);
		
	}
	
	void recordEvent(){
		//if(posInEvent.Count < 1000){
		posInEvent.Add(player.transform.position);
		//}
	}
	
	public void CancelRecording(){
		isRecording = false;
		CancelInvoke("recordEvent");
	}
	
	public void Play(){
		
		InvokeRepeating("play", 0, .005f);
	}
	
	int i = 0;
	void play(){
		if(i < posInEvent.Count){
			player.transform.position = posInEvent[i];
		}
		i++;
		
	}
}
