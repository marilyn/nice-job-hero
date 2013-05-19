using UnityEngine;
using System.Collections;

public class Hero : Player {
	
	public int points;
		
	public GameObject fist;

  private const float punchRate = 0.2f; // the punch sound can only be played 5 times per second
  private float nextPunchTime;
  public AudioClip punchSound;

  private const float jumpRate = 0.2f; // the jump sound can only be played 5 times per second
  private float nextJumpTime;
  public AudioClip jumpSound;
	
	public AudioClip acquireSound;
	
	public int GetPoints{
		get { return points; }
		set { points = value; }
	}

	// Use this for initialization
	void Start () {
		points = 0;
		fist = gameObject.transform.FindChild("fist").gameObject;
		fist.tag = "fist"; //So the punching code will know where to look
    	nextPunchTime = Time.time + punchRate;
    	nextJumpTime  = Time.time + jumpRate;
	}
	
	void Update(){
		if(!isOnGround){
			if(this.rigidbody.velocity.y < 0){
				this.renderer.material.SetTexture("_MainTex", jump[jump.Length-1]);	
			}
			if(this.rigidbody.velocity.y > 0){
				this.renderer.material.SetTexture("_MainTex", jump[jump.Length-2]);	
			}
		}
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject == Camera.main.GetComponent<GameManager>().endLevel1){	
				Camera.main.GetComponent<GameManager>().EndLevel1();
		}
		
	}
	
	float runFrame=0;
	
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
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(!stopInput){
		
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
			else {
				this.renderer.material.SetTexture("_MainTex", idle);	
			}
			
			if(Input.GetKey(KeyCode.DownArrow) && !punching){
				StartCoroutine("Punch");

        		if (Time.time > nextPunchTime) {
          			nextPunchTime = Time.time + punchRate;
          			audio.PlayOneShot(punchSound, 0.5f);
        		}
			}
			
			if(Input.GetKeyDown(KeyCode.Space) && isOnGround){
				this.rigidbody.velocity = new Vector3(0,-Physics.gravity.y/.9f,0);
				this.renderer.material.SetTexture("_MainTex" , jump[0]);

        		if (Time.time > nextJumpTime) {
          			nextJumpTime = Time.time + jumpRate;
          			audio.PlayOneShot(jumpSound, 1.0f);
        		}

				IsOnGround = false;
			}
		}
	}
	
	public override void acquires(GameObject obj) {
		if (obj.tag == "charm") {
			Charm charm = obj.GetComponent<Charm>();
			points += charm.GetPoints;
			audio.PlayOneShot(acquireSound, 1.0f); 
		}
	}
	

	

	public void AddPoints(int points) {
		this.points += points;
		
	}
	
	int punchType = 0;
	bool punching = false;

	
	IEnumerator Punch(){
		fist.transform.position = new Vector3(this.transform.position.x + this.collider.bounds.extents.x * -(int)direction, fist.transform.position.y, fist.transform.position.z);
		
		
		BoxCollider bc = fist.GetComponent<BoxCollider>();
		int i = 0;
		punching = true;
		while(fist.collider.bounds.size.x <= 1){
			if(i < 8) this.renderer.material.SetTexture("_MainTex", punch[(int)(punchType)*7]);
			else{
				this.renderer.material.SetTexture("_MainTex", punch[(int)(punchType)*7 + 1]);
			}
			bc.size = new Vector3(bc.size.x - .3f, bc.size.y, bc.size.z);
			bc.center =  new Vector3(bc.center.x - .15f * -(int)direction, bc.center.y,bc.center.z);
			i++;
			yield return null;
		}
		
		yield return new WaitForSeconds(.2f);
		bc.size = new Vector3(0, bc.size.y, bc.size.z);
		fist.transform.position = new Vector3(this.transform.position.x - this.collider.bounds.extents.x, fist.transform.position.y, fist.transform.position.z);
		bc.center = Vector3.zero;
		punching = false;
		punchType = (int)Random.Range(0.0f,2.0f);
		
	}
}
