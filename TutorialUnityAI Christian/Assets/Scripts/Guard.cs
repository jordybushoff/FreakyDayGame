using UnityEngine;
using System.Collections;


public class Guard : MonoBehaviour {

	public GameObject player;
	private NavMeshAgent navmesh;
	// Use this for initialization
	void Start () {
		navmesh = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		navmesh.destination = player.transform.position;
	}
}
