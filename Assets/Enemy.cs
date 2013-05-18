using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	Player.FaceDirection direction;
	
	int speed = 2;
	
	// Use this for initialization
	void Start () {
		direction = Player.FaceDirection.Right;
	}
	
	void OnTriggerEnter(Collider col){
		if(col.tag == "enemybound"){
			direction = (Player.FaceDirection)(-(int)direction);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		this.transform.Translate(new Vector3((int)direction * speed * Time.deltaTime,0,0));	
	}
}
