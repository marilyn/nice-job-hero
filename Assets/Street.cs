using UnityEngine;
using System.Collections;

public class Street : MonoBehaviour {
	
	GameObject streetPiece;

	// Use this for initialization
	void Start () {
		streetPiece = transform.GetChild(0).gameObject;
		
		for(int i = 0; i< 100; i++){
			GameObject temp = GameObject.Instantiate(streetPiece, streetPiece.transform.position, streetPiece.transform.rotation) as GameObject;
			temp.transform.position = new Vector3(temp.transform.position.x + streetPiece.renderer.bounds.size.x*(i+1) -.02f, temp.transform.position.y, temp.transform.position.z);
			temp.transform.parent = this.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
