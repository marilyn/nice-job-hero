using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
	
	GameObject left;
	GameObject right;
	GameObject top;
	GameObject bottom;

	// Use this for initialization
	void Start () {
		left = gameObject.transform.FindChild("left").gameObject;
		right = gameObject.transform.FindChild("right").gameObject;
		top = gameObject.transform.FindChild("top").gameObject;
		bottom = gameObject.transform.FindChild("bottom").gameObject;
		
		left.GetComponent<BoxCollider>().size = new Vector3(.2f/this.transform.lossyScale.x, 1, 1);
		left.transform.position = new Vector3(this.transform.position.x - this.collider.bounds.extents.x + left.GetComponent<BoxCollider>().size.x, this.transform.position.y, this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
