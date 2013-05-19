using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	Player.FaceDirection direction;
	
	int speed = 2;
	int HP = 2;
	bool invinc = false;
	
	// Use this for initialization
	void Start () {
		direction = Player.FaceDirection.Right;
	}
	
	void OnTriggerEnter(Collider col){
		if(col.tag == "enemybound"){
			direction = (Player.FaceDirection)(-(int)direction);
		}
	}
	
	void OnCollisionEnter(Collision col2){
		
		//Debug.Log ("COL2: " + col2.gameObject.transform.FindChild("fist").gameObject.tag);
		
		if(col2.transform.FindChild("fist")){
			BoxCollider bc = col2.transform.FindChild ("fist").GetComponent<BoxCollider>();
			if(bc.bounds.size.x > 0 && !invinc){
				HP--;
				invinc = true;
				this.rigidbody.velocity = new Vector3(-4 * (int) direction, -Physics.gravity.y/1.2f,0);
				
				if (HP <= 0){
					DestroyObject(this.gameObject);
				}
			}
		}
	}
	
	void OnCollisionExit(Collision col2){
		invinc = false;
		
	}
	
	// Update is called once per frame
	void Update () {
	
		this.transform.Translate(new Vector3((int)direction * speed * Time.deltaTime,0,0));	
	}
}
