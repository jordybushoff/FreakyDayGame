using UnityEngine;
using System.Collections;

public class JordyMovement : MonoBehaviour {
	
	public float moveSpeed = 7f;
	
	
	private Rigidbody playerRb;
	private Transform playerRotation;
	
	
	// Use this for initialization
	void Awake()
	{
		playerRotation = GetComponent<Transform>();
		playerRb = GetComponent<Rigidbody>();
	}
	// Update is called once per frame
	void FixedUpdate()
	{
		
		ContinuousMovement();
	}
	
	void Update()
	{
		MoveRotation();
	}
	
	public void ContinuousMovement()
	{
		
		playerRb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);
		
		
	}
	void MoveRotation()
	{
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
            SoundManagerScript.PlaySound("pacman_chomp");
			playerRotation.rotation = Quaternion.Euler(0f, 180f, 0f);            
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
            SoundManagerScript.PlaySound("pacman_chomp");
            playerRotation.rotation = Quaternion.Euler(0f, 0f, 0f);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
            SoundManagerScript.PlaySound("pacman_chomp");
            playerRotation.rotation = Quaternion.Euler(0f, -90f, 0f);                      
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
            SoundManagerScript.PlaySound("pacman_chomp");
            playerRotation.rotation = Quaternion.Euler(0f, 90f, 0f);
		}
	}
}
