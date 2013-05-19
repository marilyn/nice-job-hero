using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	
	public enum FaceDirection { Left  = -1, Right = 1}
	
	protected FaceDirection direction;

	protected bool isOnGround;
	
	public int speed;
	
	public EventTrigger trigger;
	
	public bool IsOnGround{
		get { return isOnGround; }
		set { isOnGround = value; }
	}
	
	public List<Vector3> posInTime = new List<Vector3>();
	
	bool wallRight = false;
	bool wallLeft = false;
	
	void Start(){
		direction = FaceDirection.Right;	
		
		trigger = GameObject.Find("EventTrigger").GetComponent<EventTrigger>();
		
		InvokeRepeating("StorePos", 1, .005f);
	}
	
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "platform"  || collision.gameObject.tag == "pitceiling"){
			IsOnGround = true;	
		}
		
		foreach(Event e in Camera.main.GetComponent<GameManager>().events){
			if(e !=null){
				if(collision.gameObject == e.collisionEventObject){
					e.playerHasCollided = true;	
				}
			}
		}
	}
	
	void StorePos(){
		posInTime.Add(this.transform.position);	
	}
	
	public void Cancel(){
		CancelInvoke("StorePos");	
	}
	
	void OnCollisionExit(Collision collision){
		foreach(Event e in Camera.main.GetComponent<GameManager>().events){
			if(e !=null){
				e.playerHasCollided = false;
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(Input.GetKey(KeyCode.RightArrow)){
			
			direction = FaceDirection.Right;
			
			this.transform.Translate(new Vector3((int)direction * speed * Time.deltaTime,0,0));	

		}
		
		if(Input.GetKey(KeyCode.LeftArrow)){
			
			direction = FaceDirection.Left;

			this.transform.Translate(new Vector3((int)direction * speed * Time.deltaTime,0,0));	

		}
		
		if(Input.GetKeyDown(KeyCode.Space) && isOnGround){
			this.rigidbody.velocity = new Vector3(0,-Physics.gravity.y/1.5f,0);
			IsOnGround = false;
		}
		
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			trigger.Play();
		}
	}
	
	public virtual void acquires(GameObject charm) {
		// should be overridden in subclass for the specific behavior
	}
}
