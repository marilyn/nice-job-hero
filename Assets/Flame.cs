using UnityEngine;
using System.Collections;

public class Flame : MonoBehaviour {
	
	
	public Texture[] fireLoop = new Texture[8];
	
	float fireFrame=0;
	
	float FireFrame{
		get{ return fireFrame; }
		set{
			if(value == fireLoop.Length){
				fireFrame = 0;	
			}
			else{
				fireFrame = value;	
			}
		}
	}

	// Use this for initialization
	void Start () {
		this.renderer.material.SetTexture("_MainTex", fireLoop[0]);
	}
	
	// Update is called once per frame
	void Update () {
		this.renderer.material.SetTexture("_MainTex", fireLoop[(int)fireFrame]);
		FireFrame+=.5f;
	
	}
}
