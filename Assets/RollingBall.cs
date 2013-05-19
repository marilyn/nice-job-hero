using UnityEngine;
using System.Collections;

public class RollingBall : MonoBehaviour {
	
	Player.FaceDirection direction;
	int speed = 0;
	private const float hitRate = 0.5f; // Half a second delay before you can hit again...
	float hitdelay;
	
	void Start () {
		direction = Player.FaceDirection.Right;
		hitdelay = Time.time + hitRate;
	}
	
	
	
	void OnCollisionEnter(Collision col2){
		
		if(col2.transform.FindChild("fist")){
			BoxCollider bc = col2.transform.FindChild ("fist").GetComponent<BoxCollider>();
			if(bc.bounds.size.x > 0 && Time.time > hitdelay){
				
				hitdelay = Time.time + hitRate;
				
				if (col2.contacts[0].normal.normalized.x > 0f){
					
					if (direction == Player.FaceDirection.Left){
						speed = 0;
					}
					else{
						if (speed == 0){
							speed = 1;
						}
						else{
							speed += speed;
						}
					}
					direction = Player.FaceDirection.Right;	
				}
				else{
					if (direction == Player.FaceDirection.Right){
						speed = 0;
					}
					else{
						if (speed == 0){
							speed = 1;
						}
						else{
							speed += speed;
						}
					}
					direction = Player.FaceDirection.Left;	
				}
				
				
			}
		}
	}
	
	
	void Update () {
		this.transform.Translate(new Vector3((int)direction * speed * Time.deltaTime,0,0));	
	}
	
	
	
}
