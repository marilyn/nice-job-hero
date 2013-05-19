using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	Player.FaceDirection direction;
	
	int speed = 2;
	int HP = 2;
	
	private const float hitRate = 0.5f; // Half a second delay before you can hit again...
	float hitdelay;
	
	int points = 250;
	
	// Use this for initialization
	void Start () {
		direction = Player.FaceDirection.Right;
		
		hitdelay = Time.time + hitRate;
	}
	
	void OnTriggerEnter(Collider col){
		if(col.tag == "enemybound"){
			direction = (Player.FaceDirection)(-(int)direction);
		}
	}
	
	void OnCollisionEnter(Collision col2){
		
		if(col2.transform.FindChild("fist")){
			BoxCollider bc = col2.transform.FindChild ("fist").GetComponent<BoxCollider>();
			if(bc.bounds.size.x > 0 && Time.time > hitdelay){
				
				hitdelay = Time.time + hitRate;
				HP--;
				this.rigidbody.velocity = new Vector3(-4 * (int) direction, -Physics.gravity.y/1.2f,0);
				
				if (HP <= 0){
					DestroyObject(this.gameObject);
					Hero hero = col2.gameObject.GetComponent<Hero>();
					hero.AddPoints(this.points);
				}
			}
		}
	}
	
	
	// Update is called once per frame
	void Update () {
	
		this.transform.Translate(new Vector3((int)direction * speed * Time.deltaTime,0,0));	
	}
}
