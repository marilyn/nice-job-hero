using UnityEngine;
using System.Collections;

public class Screen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	int currentScreen = 0;
	public  Texture[] screens;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			if(currentScreen == 1 || currentScreen ==3){
				gameObject.SetActive(false);
			}
			else{
				ChangeScreen();
			}
				
		}
	}
	
	public void ChangeScreen(){
		currentScreen++;
		this.renderer.material.SetTexture("_MainTex", screens[currentScreen]);
	}
}
