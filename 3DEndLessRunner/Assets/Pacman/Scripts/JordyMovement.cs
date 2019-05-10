using UnityEngine;
using System.Collections;

public class JordyMovement : MonoBehaviour {
	
	public float moveSpeed = 7f;
	
	
	private Rigidbody playerRb;
	private Transform playerRotation;
	public AudioSource MovementPackman;
	
	
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
			MovementPackman.Play();
			playerRotation.rotation = Quaternion.Euler(0f, 180f, 0f);            
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{

			MovementPackman.Play();
            playerRotation.rotation = Quaternion.Euler(0f, 0f, 0f);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{

			MovementPackman.Play();
            playerRotation.rotation = Quaternion.Euler(0f, -90f, 0f);                      
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			MovementPackman.Play();
            playerRotation.rotation = Quaternion.Euler(0f, 90f, 0f);
		}
	}
}
