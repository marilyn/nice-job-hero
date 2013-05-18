using UnityEngine;
using System.Collections;

public class Charm : MonoBehaviour {
	public Player acquirer;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "hero"){
			acquirer = collision.gameObject.GetComponent<Player>();
			StartCoroutine(Acquired());	
		}
	}
	
		
	IEnumerator Acquired(){
		acquirer.acquires(this.gameObject);
		Destroy(this.gameObject);
		
		yield return null;
	}
}
