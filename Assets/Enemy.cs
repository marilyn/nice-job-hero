using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	Player.FaceDirection direction;
 	public GameObject Explosion;
	
	int speed = 2;
	int HP = 2;
	
	private const float hitRate = 0.5f; // Half a second delay before you can hit again...
	float hitdelay;
	float nextFireTime;
	float fireRate = 10;
	
	int points = 250;
	
	public GameObject flame;
	public GameObject sampleFlame;
	
	// Use this for initialization
	void Start () {
		direction = Player.FaceDirection.Left;
		
		hitdelay = Time.time + hitRate;
		nextFireTime = Time.time + fireRate;
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
				
				if (HP == 0){
					//DestroyObject(this.gameObject);
					this.gameObject.renderer.material.SetColor("_Color", Color.red);
					speed = 0;
					this.gameObject.audio.Stop();
          			//Instantiate(Explosion, this.gameObject.transform.position, this.gameObject.transform.rotation);
					// mark enemy as dead
					Hero hero = col2.gameObject.GetComponent<Hero>();
					hero.AddPoints(this.points);
				}
			}
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFireTime) {
          	nextFireTime = Time.time + fireRate;
			Fire();
		}
	}
	
	void Fire() {
		flame = GameObject.Instantiate(sampleFlame, new Vector3(this.transform.position.x + (int)direction * 10, this.transform.position.y, this.transform.position.z), Quaternion.Euler(90,180,0)) as GameObject;
		Destroy(flame,2);
	}
}
