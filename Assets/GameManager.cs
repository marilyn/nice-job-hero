using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public GameObject Hero;
	public GameObject Benedict;

	public GameObject endLevel1;
	
	public Event[] events = new Event[3];
	
	public GameObject player1Start;
	public GameObject player2Start;


	// Use this for initialization
	void Start () {
		GameObject hero = GameObject.Instantiate(Hero, player1Start.transform.position, Quaternion.Euler(90,180,0)) as GameObject;
		Camera.main.GetComponent<CameraFollow>().player = hero;
		hero.name = "Hero";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void EndLevel1(){
		Hero.SetActive(false);
		
		GameObject hero = GameObject.Instantiate(Benedict, player2Start.transform.position, Quaternion.identity) as GameObject;
		Camera.main.GetComponent<CameraFollow>().player = hero;
		
	}
}
