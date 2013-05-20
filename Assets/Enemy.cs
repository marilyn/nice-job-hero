using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public Player.FaceDirection direction;
 	public GameObject Explosion;
	
	int speed = 2;
	public int HP = 2;
	
	private const float hitRate = 0.5f; // Half a second delay before you can hit again...
	float hitdelay;
	float nextFireTime;
	float endFireTime;
	float fireRate = 5;
	float fireLength = 1;
	bool isStartingFire;
	bool isFiring;
	
	int points = 250;
	
	public GameObject flame;
	public GameObject sampleFlame;
	
	GameManager gameManager;
	
	public Texture idle;
	public Texture[] move = new Texture[4];
	public Texture[] fire = new Texture[8];
	public Texture[] die = new Texture[10];
	public Texture[] docile = new Texture[10];
	
	float moveFrame=0;
	
	float MoveFrame{
		get{ return moveFrame; }
		set{
			if (value == move.Length) {
				moveFrame = 0;	
			} else {
				moveFrame = value;	
			}
		}
	}
	
	float dieFrame=0;
	
	float DieFrame{
		get{ return dieFrame; }
		set{
			if (value < die.Length) {
				dieFrame = value;	
			} 
		}
	}
	
	float docileFrame=0;
	
	float DocileFrame{
		get{ return docileFrame; }
		set{
			if (value == docile.Length) {
				docileFrame = 0;	
			} else {
				docileFrame = value;	
			} 
		}
	}
	
	float fireFrame=0;
	
	float FireFrame{
		get{ return fireFrame; }
		set{
			if (value == fire.Length || value < 0) {
				fireFrame = 0;	
			} else {
				fireFrame = value;	
			} 
		}
	}
	
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
				Camera.main.GetComponent<HUD>().luck = -10;
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
			if(bc.bounds.size.x > 0 && Time.time > hitdelay && HP > 0){
				
				hitdelay = Time.time + hitRate;
				HP--;
				this.rigidbody.velocity = new Vector3(-4 * (int) direction, -Physics.gravity.y/1.2f,0);
				
				if (HP == 0){
					//DestroyObject(this.gameObject);
					speed = 0;
					this.gameObject.audio.Stop();
					
          			//Instantiate(Explosion, this.gameObject.transform.position, this.gameObject.transform.rotation);
					// mark enemy as dead
					Hero hero = col2.gameObject.GetComponent<Hero>();
					hero.AddPoints(this.points);
				}
			}
			//Remove health if not punching...
			else{
				
				
			}
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("Hero") != null) { //Only when HERO is out
			if (HP > 0) { //Only fire & move when not 'dead'
				if (Time.time > nextFireTime) {
	          		nextFireTime = Time.time + fireRate;
					endFireTime = Time.time + fireLength;
					isStartingFire = true;
				}
				
				if (isStartingFire) {			
					// baddie opening up his hatch
					this.renderer.material.SetTextureScale("_MainTex", new Vector2((int)direction,1));
					this.renderer.material.SetTexture("_MainTex", fire[(int)fireFrame]); 
					FireFrame+=.5f;
					if (fireFrame == 0) {
						isStartingFire = false;
						Fire();
						isFiring = true;
						FireFrame = fire.Length - 1;
					}
				} else if (Time.time > endFireTime) {
					// closing hatch
					isFiring = false;
					this.renderer.material.SetTextureScale("_MainTex", new Vector2((int)direction,1));
					this.renderer.material.SetTexture("_MainTex", fire[(int)fireFrame]); 
					FireFrame-=.5f;
					if (fireFrame == 0) {
						endFireTime += Time.time + fireRate + fireLength;
					}
				} else if (isFiring) {
					this.renderer.material.SetTextureScale("_MainTex", new Vector2((int)direction,1));
					this.renderer.material.SetTexture("_MainTex", fire[(int)fireFrame]); 				
				} else {
					// regular motion
					this.renderer.material.SetTextureScale("_MainTex", new Vector2((int)direction,1));
					this.renderer.material.SetTexture("_MainTex", move[(int)moveFrame]); 
					MoveFrame+=.5f;
				}
			} else {
				this.renderer.material.SetTextureScale("_MainTex", new Vector2((int)direction,1));
				this.renderer.material.SetTexture("_MainTex", die[(int)dieFrame]); 
				DieFrame+=.2f;
			}
		} else { // Benedict
			if (HP > 0) { //Only when not 'dead'
				this.renderer.material.SetTextureScale("_MainTex", new Vector2((int)direction,1));
				this.renderer.material.SetTexture("_MainTex", docile[(int)docileFrame]); 
				DocileFrame+=.5f;
			} 
		}
				
		this.transform.Translate(new Vector3((int)direction * speed * Time.deltaTime,0,0));		
		
		
	}
	
	void Fire() {
		// shooting 
		this.renderer.material.SetTextureScale("_MainTex", new Vector2(-(int)direction,1));
		flame = GameObject.Instantiate(sampleFlame, new Vector3(this.transform.position.x - (int)direction*1.5f, this.transform.position.y + .76f, this.transform.position.z), Quaternion.Euler(90,180,0)) as GameObject;
		flame.gameObject.transform.parent = this.transform;
		Destroy(flame,1);
	}
	
	
	IEnumerator reappear(){
		yield return new WaitForSeconds(1.5f);
		this.collider.enabled = true;
		this.rigidbody.useGravity = true;
	}
}
