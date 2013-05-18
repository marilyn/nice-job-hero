using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	
	public enum FaceDirection { Left  = -1, Right = 1}
	
	FaceDirection direction;

	private bool isOnGround;
	
	public int speed;
	
	public bool IsOnGround{
		get { return isOnGround; }
		set { isOnGround = value; }
	}
	
	public List<Vector3> posInTime = new List<Vector3>();
		
	
	public GameObject fist;
	
	bool wallRight = false;
	bool wallLeft = false;
	
	void Start(){
		direction = FaceDirection.Right;	
		fist = gameObject.transform.FindChild("fist").gameObject;
		
		InvokeRepeating("StorePos", 1, .005f);
	}
	
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "platform"  || collision.gameObject.tag == "pitceiling"){
			IsOnGround = true;	
		}
	}
	
	void StorePos(){
		posInTime.Add(this.transform.position);	
	}
	
	public void Cancel(){
		CancelInvoke("StorePos");	
	}
	
	/*void OnCollisionExit(Collision collision){
		if(collision.gameObject.tag == "platform"){
			IsOnGround = false;	
		}
	}*/
	
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
		
		if(Input.GetKey(KeyCode.DownArrow)){
			StartCoroutine(Punch());
		}
		
		if(Input.GetKeyDown(KeyCode.Space) && isOnGround){
			this.rigidbody.velocity = new Vector3(0,-Physics.gravity.y/1.5f,0);
			IsOnGround = false;
		}
	}
	
	IEnumerator Punch(){
		fist.transform.position = new Vector3(this.transform.position.x + this.collider.bounds.extents.x * (int)direction, fist.transform.position.y, fist.transform.position.z);
		
		BoxCollider bc = fist.GetComponent<BoxCollider>();
		
		while(fist.collider.bounds.size.x <= 1){
			bc.size = new Vector3(bc.size.x + .3f, bc.size.y, bc.size.z);
			bc.center =  new Vector3(bc.center.x + .15f * (int)direction, bc.center.y,bc.center.z);
			yield return null;
		}
		
		yield return new WaitForSeconds(.2f);
		bc.size = new Vector3(0, bc.size.y, bc.size.z);
		fist.transform.position = new Vector3(this.transform.position.x + this.collider.bounds.extents.x, fist.transform.position.y, fist.transform.position.z);
		bc.center = Vector3.zero;
		
	}
	
	public void acquires(GameObject charm) {
		// should be overridden in subclass for the specific behavior
	}
}
