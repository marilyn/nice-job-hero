using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	Player.FaceDirection direction;
 	public GameObject Explosion;
	
	int speed = 2;
	public int HP = 2;
	
	private const float hitRate = 0.5f; // Half a second delay before you can hit again...
	float hitdelay;
	float nextFireTime;
	float fireRate = 5;
	
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
	
	
	void onCollisionExit(Collision col){
		this.collider.enabled = true;
		this.rigidbody.useGravity = true;
	}
	
	void OnCollisionEnter(Collision col2){
		
		if(col2.gameObject.tag == "benedict"){
			if (HP <= 0){ //Explodes if already dead by the time Benedict gets there
				Instantiate(Explosion, this.gameObject.transform.position, this.gameObject.transform.rotation);
				DestroyObject(this.gameObject);
			}
			else{
				this.rigidbody.useGravity = false;
				this.collider.enabled = false;
				StartCoroutine ("reappear");
			}
		}
		
		
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
		if(GameObject.Find("Hero") != null){ //Only when HERO is out
			if (Time.time > nextFireTime && HP > 0) { //Only when not 'dead'
          		nextFireTime = Time.time + fireRate;
				Fire();
			}
		}
				
		this.transform.Translate(new Vector3((int)direction * speed * Time.deltaTime,0,0));	
	}
	
	void Fire() {
		flame = GameObject.Instantiate(sampleFlame, new Vector3(this.transform.position.x + (int)direction, this.transform.position.y, this.transform.position.z), Quaternion.Euler(90,180,0)) as GameObject;
		Destroy(flame,1);
	}
	
	
	IEnumerator reappear(){
		
		yield return new WaitForSeconds(1.5f);
		this.collider.enabled = true;
		this.rigidbody.useGravity = true;
	}
}
