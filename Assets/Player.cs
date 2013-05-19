using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	
	public enum FaceDirection { Left  = -1, Right = 1}
	
	protected FaceDirection direction;

	protected bool isOnGround;
	
	public int speed;
	
	public Texture idle;
	public Texture[] jump = new Texture[5];
	public Texture[] run =  new Texture[10];
	public Texture[] punch =  new Texture[14];
	
	//public EventTrigger trigger;
	
	public bool IsOnGround{
		get { return isOnGround; }
		set { 
      		if(value) {
				// restore friction on the ground
				this.gameObject.collider.material.frictionCombine = PhysicMaterialCombine.Average;
				this.gameObject.collider.material.dynamicFriction = 0.4f;
				this.gameObject.collider.material.staticFriction = 0.4f;
      		} else {
				// remove friction while in the air so we don't stick to walls
				this.gameObject.collider.material.frictionCombine = PhysicMaterialCombine.Multiply;
				this.gameObject.collider.material.dynamicFriction = 0.0f;
				this.gameObject.collider.material.staticFriction = 0.0f;
      		}
      		isOnGround = value;
		}
	}
	
	public List<Vector3> posInTime = new List<Vector3>();
	
	public bool stopInput = false;
	
	bool wallRight = false;
	bool wallLeft = false;
	
	void Start(){
		direction = FaceDirection.Right;	
		
		//trigger = GameObject.Find("EventTrigger").GetComponent<EventTrigger>();
		
		//InvokeRepeating("StorePos", 1, .005f);
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
	
	void Update(){
		/*if(!isOnGround){
			if(this.rigidbody.velocity.y < 0){
				this.renderer.material.SetTexture("_MainTex", jump[jump.Length-1]);	
			}
			if(this.rigidbody.velocity.y > 0){
				this.renderer.material.SetTexture("_MainTex", jump[jump.Length-2]);	
			}
		}*/
	}
	
	/*float runFrame=0;
	
	float RunFrame{
		get{ return runFrame; }
		set{
			if(value == run.Length){
				runFrame = 0;	
			}
			else{
				runFrame = value;	
			}
		}
	}*/
	
	// Update is called once per frame
	void FixedUpdate () {
		
		/*if(!stopInput){
		
			if(Input.GetKey(KeyCode.LeftArrow)){
				
				//if(direction != FaceDirection.Right){
					direction = FaceDirection.Right;
				this.renderer.material.SetTextureScale("_MainTex", new Vector2(-(int)direction,1));
				if(isOnGround){
					
					this.renderer.material.SetTexture("_MainTex", run[(int)runFrame]);
					RunFrame+=.5f;
				}
				//}
				
				this.transform.Translate(new Vector3((int)direction * speed * Time.deltaTime,0,0));	
	
			}
			
			else if(Input.GetKey(KeyCode.RightArrow)){
				
				//if(direction != FaceDirection.Left){
					direction = FaceDirection.Left;
				this.renderer.material.SetTextureScale("_MainTex", new Vector2(-(int)direction,1));
				if(isOnGround){
					
					this.renderer.material.SetTexture("_MainTex", run[(int)runFrame]);
					RunFrame+=.5f;
				}
				//}
				
	
				this.transform.Translate(new Vector3((int)direction * speed * Time.deltaTime,0,0));	
	
			}
			else if (!punching){
				this.renderer.material.SetTexture("_MainTex", idle);	
			}
			
			if(Input.GetKey(KeyCode.DownArrow) && !punching){
				StartCoroutine("Punch");
			}
			
			if(Input.GetKeyDown(KeyCode.Space) && isOnGround){
				this.rigidbody.velocity = new Vector3(0,-Physics.gravity.y/1.5f,0);
				this.renderer.material.SetTexture("_MainTex" , jump[0]);
				IsOnGround = false;
			}
		}*/
	}
	


	public virtual void acquires(GameObject charm) {

		// should be overridden in subclass for the specific behavior
	}
}
