using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public GameObject Hero;
	public GameObject Benedict;

	public GameObject endLevel1;
	
	public Event[] events = new Event[3];
	
	public GameObject player1Start;
	public GameObject player2Start;

	public GameObject currentPlayer;


	// Use this for initialization
	void Start () {
		currentPlayer = GameObject.Instantiate(Hero, player1Start.transform.position, Quaternion.Euler(90,180,0)) as GameObject;
		Camera.main.GetComponent<CameraFollow>().player = currentPlayer;
		currentPlayer.SetActive(true);
		currentPlayer.name = "Hero";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void EndLevel1(){
		if(currentPlayer.name == "Hero"){
			currentPlayer.SetActive(false);
			
			currentPlayer = GameObject.Instantiate(Benedict, player1Start.transform.position, Quaternion.Euler(90,180,0)) as GameObject;
			Camera.main.GetComponent<CameraFollow>().player = currentPlayer;
		}
		
	}
}
