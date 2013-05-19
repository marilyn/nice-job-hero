using UnityEngine;
using System.Collections;

public class PitCeilingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.rigidbody.useGravity = false;
		this.rigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
	  
	}
	
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "hero"){
			StartCoroutine(Fall());	
		}
	}
	
	
	IEnumerator Fall(){
		yield return new WaitForSeconds(1);
		
		this.rigidbody.isKinematic = false;
		this.rigidbody.useGravity = true;	
	}
}
