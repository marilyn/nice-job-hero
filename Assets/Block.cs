using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	
	private bool isBroken;
	
	public bool IsBroken{
		get { return isBroken; }
	}
	
	// Use this for initialization
	void Start () {
		isBroken = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "fist" && isBroken == false) {
			Hero hero = collision.gameObject.GetComponent<Hero>();
			isBroken = true;	
			foreach (Rigidbody shard in this.GetComponentsInChildren<Rigidbody>()) {
				shard.useGravity = true;
				shard.isKinematic = false;
				shard.AddExplosionForce(1,new Vector3((int)hero.direction,0,0),1);
			}
		} 
		
	}
}
