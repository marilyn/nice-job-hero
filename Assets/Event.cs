using UnityEngine;
using System.Collections;

public class Event : MonoBehaviour {
	
	public GameObject player1TriggerObject;
	public GameObject player2TriggerObject;
	
	EventTrigger player1Trigger;
	EventTrigger player2Trigger;
	
	public float recordTime = 4;
	
	public GameObject collisionEventObject;
	
	public bool playerHasCollided = false;
	
	private bool doneRecording = false;
	
	
	
	public Event(EventTrigger e1, GameObject col, EventTrigger e2){
		player1Trigger = e1;
		player2Trigger = e2;
		collisionEventObject = col;
	}

	// Use this for initialization
	void Start () {
		player1Trigger = player1TriggerObject.GetComponent<EventTrigger>();
		player2Trigger = player2TriggerObject.GetComponent<EventTrigger>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player1Trigger != null && player1Trigger.isTriggered && !doneRecording){
			player1Trigger.RecordEvent();
			player1Trigger.isTriggered = false;
		}
		if(collisionEventObject !=null && player1Trigger != null && player1Trigger.isRecording && !doneRecording){
			if(playerHasCollided){
				player1Trigger.isRecording = false;
				StartCoroutine("WaitBeforeStopRecording");
			}
		}
		
		if(doneRecording && player2TriggerObject != null && Input.GetKeyDown(KeyCode.Alpha1)){
			player1Trigger.Play();
			
		}
		
		
	}
	
	IEnumerator WaitBeforeStopRecording(){
		
		yield return new WaitForSeconds(recordTime);
		doneRecording = true;
		player1Trigger.CancelRecording();
	}
}
