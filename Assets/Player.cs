using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private bool isOnGround;
	
	public bool IsOnGround{
		get { return isOnGround; }
		set { isOnGround = value; }
		
	}

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "platform"){
			isOnGround = true;
		}
        
    }
	
	void OnCollisionExit(Collision collision){
		Debug.Log(collision.gameObject.tag);
		if(collision.gameObject.tag == "platform"){
			isOnGround = false;	
		}
			
	}
	
	IEnumerator Jump(){
		
		while(this.transform.position.y < this.transform.position.y+1){
			this.transform.Translate(new Vector3(0, 2* Time.deltaTime, 0));
			Debug.Log(this.transform.position);
			yield return null;
		}
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(Input.GetKey(KeyCode.RightArrow)){
			this.transform.Translate(new Vector3(2* Time.deltaTime,0,0));	
			//this.rigidbody.velocity = new Vector3(2,0,0);
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)){
			this.transform.Translate(new Vector3(-2* Time.deltaTime,0,0));	
		}
		
		if(Input.GetKeyDown(KeyCode.Space) && isOnGround){
			this.rigidbody.velocity = new Vector3(0,-Physics.gravity.y/1.5f,0);
		}
	}
}
