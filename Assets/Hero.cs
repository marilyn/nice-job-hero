using UnityEngine;
using System.Collections;

public class Hero : Player {
	
	public int points;
		
	public GameObject fist;
	
	public int GetPoints{
		get { return points; }
	}

	// Use this for initialization
	void Start () {
		points = 0;
		fist = gameObject.transform.FindChild("fist").gameObject;
	}
	
	// Update is called once per frame
	// Not sure why Hero isn't inheriting this from Player...
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
		
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			trigger.Play();
		}
	}
	
	public override void acquires(GameObject obj) {
		if (obj.tag == "charm") {
			Charm charm = obj.GetComponent<Charm>();
			points += charm.GetPoints;
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
}
