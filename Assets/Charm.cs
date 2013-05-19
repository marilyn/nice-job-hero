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
	
	// Update is called once per frame
	void Update () {
		
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
