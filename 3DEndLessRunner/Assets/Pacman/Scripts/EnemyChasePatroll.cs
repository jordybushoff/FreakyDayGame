using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasePatroll : MonoBehaviour
{
	public Transform player;
	public Transform head;
	static Animator Fight;

	string state = "patrol";
	public GameObject[] waypoints;
	int currentWP = 0;
	float rotSpeed = 1.0f;
	float speed = 1.5f;
	float accuracyWP = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
		Fight = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 direction = player.position - this.transform.position;
		direction.y = 0;
		float angle = Vector3.Angle(direction, head.up);

		if (state == "patrol" && waypoints.Length > 0) 
		{
			Fight.SetBool("isAttacking", false);
			Fight.SetBool("isWalking", true);
			if(Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
			{
				currentWP++;
				if(currentWP >= waypoints.Length)
				{
					currentWP = 0;
			}
		}

		direction = waypoints [currentWP].transform.position - transform.position;
		this.transform.rotation = Quaternion.Slerp (transform.rotation,
		                     Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
		this.transform.Translate (0, 0, Time.deltaTime * speed);

    }

	if(Vector3.Distance(player.position, this.transform.position) < 10 && (angle < 30 || state == "pursuing"))
	{

		state = "pursuing";
		this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
		                                           Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

		if(direction.magnitude > 5)
		{
			this.transform.Translate(0, 0, Time.deltaTime * speed);
			Fight.SetBool("isWalking",true);
			Fight.SetBool("isAttacking",false);

		}

		else
		{
			Fight.SetBool("isAttacking", true);
			Fight.SetBool("isWalking", false);

		}
	

	}

	else
	{
		Fight.SetBool("isWalking", true);
		Fight.SetBool("isAttacking", false);
			state = "patrol";
	}
}
}
