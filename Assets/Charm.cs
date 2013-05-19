using UnityEngine;
using System.Collections;

public class Charm : MonoBehaviour {
	public Player acquirer;
	
	public int points;
	public int luck;
	
	public int GetPoints{
		get { return points; }
	}
	
	public int GetLuck{
		get { return luck; }
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	void Update(){
		transform.position = new Vector3 (transform.position.x , transform.position.y + (Mathf.PingPong(Time.time, 2) - 1)/100, transform.position.z);
	}
	
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "hero" || collision.gameObject.tag == "benedict"){
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
