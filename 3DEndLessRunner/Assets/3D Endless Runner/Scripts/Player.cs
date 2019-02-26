﻿
using UnityEngine;
using System.Collections;


public enum PlayerStates{
	Start,
	Ready,
	Live,
	Die
}
public class Player : MonoBehaviour {
	public PlayerStates CurrentPlayerState = PlayerStates.Start;
	Rigidbody _Rigidbody;
	GameManager _GameManager;
	Animator _Animator;
	Vector3 LastPosition;
	AudioSource _AudioSource;
	public int JumpForce;
	public int Speed;
	public AudioClip JetPackAudio;
	public AudioClip DieAudio;
	public ParticleSystem SmokeParticle;

	void Awake()
	{


		//  I have used -200 gravity in this game
		Physics.gravity = new Vector3(0,-200f,0);

	}

	void Start () {
		_Rigidbody = GetComponent <Rigidbody> ();
		_Animator  = GetComponent <Animator> ();
		_AudioSource = GetComponent <AudioSource> ();
		_GameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent <GameManager> ();
	}

	void Update () {
		if (_GameManager.CurrentState == GameState.InGame) 
		{
			_AudioSource.clip = JetPackAudio;
			if(_AudioSource.isPlaying == false)
			_AudioSource.Play ();
			_Animator.SetBool ("InGame",true);
			GetCurrentPlayerState (PlayerStates.Live);
		}

		if (CurrentPlayerState == PlayerStates.Live) {

			_Rigidbody.velocity = new Vector2 (Speed,_Rigidbody.velocity.y); // Speed

			if (Input.GetMouseButton (0))  // if left mouse button pressed
			{

				_Rigidbody.velocity = new Vector2 (_Rigidbody.velocity.x,JumpForce); // Jump
			}
			/*
				if (Input.GetMouseButtonDown (0)) {
					SmokeParticle.Play ();
				}else if (Input.GetMouseButtonUp (0)){
					SmokeParticle.Stop();
				}
				*/

		}
	}


	void OnCollisionEnter(Collision Coll)
	{
		if (CurrentPlayerState == PlayerStates.Live) {
			if (Coll.gameObject.tag == "Trap") 
			{
				LastPosition = new Vector3 (transform.position.x+400,0,0);
				GetCurrentPlayerState (PlayerStates.Die); 
			}
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (CurrentPlayerState == PlayerStates.Live) {
			if (other.tag == "Score") 
			{
				_GameManager.GetScore (1);
			}
		}

	}

	public void GetCurrentPlayerState (PlayerStates State)
	{
		CurrentPlayerState = State; //GetState
		Refresh ();
	}

	void Refresh(){
		switch (CurrentPlayerState)
		{
		case PlayerStates.Ready:
			{
				transform.position = LastPosition;
				transform.rotation = Quaternion.Euler (0,0,0);
				_Rigidbody .velocity = new Vector3 (0,0,0);
				_Rigidbody.useGravity = false;
				_Rigidbody.freezeRotation = true;
			}
			break;
		case PlayerStates.Live:
			{
				_Rigidbody.useGravity = true;
			}
			break;
		case PlayerStates.Die:
			{
				_Rigidbody.freezeRotation = false;
				_AudioSource.PlayOneShot (DieAudio);
				_Rigidbody.velocity = new Vector3 (0,0,0);
				_GameManager.GetCurrentState (GameState.EndGame);
			}
			break;
		} 
	}
}