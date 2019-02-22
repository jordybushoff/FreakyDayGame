using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	public float Ypos;
	public float Ymin,Ymax;

	void Start () {
		Ypos = Random.Range (Ymin ,Ymax);
		transform.position = new Vector3 (transform.position.x, Ypos,0);
	}
	
 
	void OnTriggerEnter (Collider Other){
		if (Other.tag == "Destroyer")
			Destroy (gameObject);
	}
}
