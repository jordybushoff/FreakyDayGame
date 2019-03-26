using UnityEngine;
using System.Collections;

public class Looker : MonoBehaviour {

	public GameObject guard;

	private float reset = 5;
	private bool movingDown;
	// Use this for initialization
	//void Start () 
	//{
	
	//}
	
	// Update is called once per frame
	void Update () {
		if (movingDown == false)
			transform.position -= new Vector3(0, 0, 0.1f);
		else
			transform.position += new Vector3(0, 0, 0.1f);

		if (transform.position.z > 10)
			movingDown = false;
		else if (transform.position.z < -10)
			movingDown = true;

		reset -= Time.deltaTime;
		if (reset < 0)
		{
			guard.GetComponent<Guard>().enabled = false;
			GetComponent<SphereCollider>().enabled = true;

		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			guard.GetComponent<Guard>().enabled = true;
			reset = 5;
			GetComponent<SphereCollider>().enabled = false;
		}
	}
}
