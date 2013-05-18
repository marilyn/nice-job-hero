using UnityEngine;
using System.Collections;

public class Charm : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "hero"){
			StartCoroutine(Acquired());	
		}
	}
	
		
	IEnumerator Acquired(){
		// notify game manager of acquisition
		// notify player of acquisition
		Destroy(this.gameObject);
		
		yield return null;
	}
}
