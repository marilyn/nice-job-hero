using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.RightArrow)){
			this.transform.Translate(new Vector3(2* Time.deltaTime,0,0));	
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)){
			this.transform.Translate(new Vector3(-2* Time.deltaTime,0,0));	
		}
		
		if(Input.GetKeyDown(KeyCode.Space)){
			rigidbody.AddForce(new Vector3(0, 20, 0));	
		}
	}
}
