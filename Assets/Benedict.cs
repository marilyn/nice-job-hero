using UnityEngine;
using System.Collections;

public class Benedict : Player {
	
	private bool isSlow; /* slower than usual, even */
	
	private int luck;
	
	public int GetLuck{
		get { return luck; }
	}
	
	public bool IsSlow{
		get { return isSlow; }
	}

	// Use this for initialization
	void Start () {
		isSlow = false;
		luck = 50;
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
	
	float walkFrame=0;
	
	float WalkFrame{
		get{ return walkFrame; }
		set{
			if(value == run.Length){
				walkFrame = 0;	
			}
			else{
				walkFrame = value;	
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//if(!stopInput){
		
			if(Input.GetKey(KeyCode.LeftArrow)){
			//Debug.Log ("FUCK");
				
				//if(direction != FaceDirection.Right){
					direction = FaceDirection.Right;
					this.renderer.material.SetTextureScale("_MainTex", new Vector2(-(int)direction,1));
					//if(isOnGround){
					
						this.renderer.material.SetTexture("_MainTex", run[(int)walkFrame]);
						WalkFrame+=.25f;
					
					//}
				//}
				
				this.transform.Translate(new Vector3((int)direction * speed * Time.deltaTime,0,0));	
	
			}
			
			else if(Input.GetKey(KeyCode.RightArrow)){
				

					direction = FaceDirection.Left;
					this.renderer.material.SetTextureScale("_MainTex", new Vector2(-(int)direction,1));
					
					this.renderer.material.SetTexture("_MainTex", run[(int)walkFrame]);
					WalkFrame+=.25f;
				
	
				this.transform.Translate(new Vector3((int)direction * speed * Time.deltaTime,0,0));	
	
			}
			else {
				this.renderer.material.SetTexture("_MainTex", idle);	
			}

	}
	
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == "block") {
			Block block = collision.gameObject.GetComponent<Block>();
			if (block.IsBroken && isSlow == false) {
				speed = speed / 2;
				isSlow = true;
			}
		}
	}
	
	void OnCollisionExit (Collision collision) {
		if (collision.gameObject.tag == "block" ) {
			Block block = collision.gameObject.GetComponent<Block>();
			if (block.IsBroken && isSlow == true) {
				speed = speed * 2;
				isSlow = false;
			}
		}
	}
	
	public override void acquires(GameObject obj) {
		if (obj.tag == "charm") {
			Charm charm = obj.GetComponent<Charm>();
			luck += charm.GetLuck;
			
			// Max out luck at 100
			if (luck > 100) {
				luck = 100;
			}
		}
	}
	
}
