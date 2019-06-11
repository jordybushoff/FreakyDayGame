// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class PatrollAi : MonoBehaviour {
	
	public Transform[] points;
	private int destPoint = 0;
	private NavMeshAgent agent;
	public Transform Player;
	public Animation Walk;
	public Animation Atack;


	//int MaxDist = 100;
	float MinDist = 5.0f;

	//public var smoothTime : float = 10.0f;
	//Vector3 used to store the velocity of the enemy
	//private var smoothVelocity : Vector3 = Vector3.zero;




	
	
	void Start () {

		agent = GetComponent<NavMeshAgent>();
		Walk = GetComponent<Animation> ();
		Atack = GetComponent<Animation> ();

		Walk.Play ("isWalking");
		
		// Disabling auto-braking allows for continuous movement
		// between points (ie, the agent doesn't slow down as it
		// approaches a destination point).
		agent.autoBraking = false;
		Player = GameObject.FindGameObjectWithTag ("Player").transform;
		
		GotoNextPoint();
	}
	
	
	void GotoNextPoint() {
		// Returns if no points have been set up
		Walk.Play ("isWalking");
		if (points.Length == 0)
			return;
		
		// Set the agent to go to the currently selected destination.
		agent.destination = points[destPoint].position;
		
		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % points.Length;
	}
	
	
	void Update () {
		// Choose the next destination point when the agent gets
		// close to the current one.
		if (!agent.pathPending && agent.remainingDistance < 0.5f)
			GotoNextPoint();

		float distance = Vector3.Distance(transform.position, Player.position);

		if(distance < MinDist)
		{
			//Move the enemy towards the player with smoothdamp
			agent.destination = Player.transform.position;
			Atack.Play ("isAttacking");
		}

}
}