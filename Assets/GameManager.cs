using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public GameObject Hero;
	public GameObject Benedict;

	public GameObject endLevel1;
	
	public Event[] events = new Event[3];


	// Use this for initialization
	void Start () {
		GameObject hero = GameObject.Instantiate(Hero, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z +10), Quaternion.identity) as GameObject;
		Camera.main.GetComponent<CameraFollow>().player = hero;
		hero.name = "Hero";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void EndLevel1(){
		Hero.SetActive(false);
		
	}
}
