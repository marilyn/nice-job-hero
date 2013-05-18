using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	Player.FaceDirection direction;
	
	int speed = 2;
	int HP = 2;
	
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
		//Debug.Log("col2: " + col2.gameObject.transform.FindChild ("fist").tag);
		
	if(col2.transform.FindChild("fist")){
			BoxCollider bc = col2.transform.FindChild ("fist").GetComponent<BoxCollider>();
			if(bc.bounds.size.x > 0){
			HP--;
			if (HP <= 0){
				DestroyObject(this.gameObject);
			}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		this.transform.Translate(new Vector3((int)direction * speed * Time.deltaTime,0,0));	
	}
}
