using UnityEngine;
using System.Collections;

public class Benedict : Player {
	
	private bool isSlow; /* slower than usual, even */
	
	private int luck;
	
	public int GetLuck{
		get { return luck; }
	}
	
	public bool IsSlow{
		get { return isSlow; }
	}

	// Use this for initialization
	void Start () {
		isSlow = false;
		luck = 50;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == "block") {
			Block block = collision.gameObject.GetComponent<Block>();
			if (block.IsBroken && isSlow == false) {
				speed = speed / 2;
				isSlow = true;
			}
		}
	}
	
	void OnCollisionExit (Collision collision) {
		if (collision.gameObject.tag == "block" ) {
			Block block = collision.gameObject.GetComponent<Block>();
			if (block.IsBroken && isSlow == true) {
				speed = speed * 2;
				isSlow = false;
			}
		}
	}
	
	public override void acquires(GameObject obj) {
		if (obj.tag == "charm") {
			Charm charm = obj.GetComponent<Charm>();
			luck += charm.GetLuck;
			
			// Max out luck at 100
			if (luck > 100) {
				luck = 100;
			}
		}
	}
	
}
