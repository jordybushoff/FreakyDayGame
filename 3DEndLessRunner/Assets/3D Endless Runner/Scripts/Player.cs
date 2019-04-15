
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
    GameObject player;
    GameObject trapup;
    GameObject trapdown;
	AudioSource _AudioSource;
	public int JumpForce;
	public int Speed;
    public float PilarDistanceup;
    public float PilarDistancedown;
    public AudioClip JetPackAudio;
	public AudioClip DieAudio;
	public ParticleSystem SmokeParticle;

	void Awake()
	{


		//zwaartekracht
		Physics.gravity = new Vector3(0, -350f,0);

	}

	void Start () {     
        _Rigidbody = GetComponent <Rigidbody> ();
		_Animator  = GetComponent <Animator> ();
		_AudioSource = GetComponent <AudioSource> ();
		_GameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent <GameManager> ();
        trapup = GameObject.FindGameObjectWithTag("TrapUp");
        trapdown = GameObject.FindGameObjectWithTag("Trap");
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

            player = GameObject.FindGameObjectWithTag("Player");
            _Rigidbody.velocity = new Vector2 (Speed,_Rigidbody.velocity.y); // Speed

           // RaycastHit Geraakt1;
            //RaycastHit Geraakt2;

            //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Geraakt1))
            //{
            //    PilarDistanceup = Geraakt1.distance;

            //    if (PilarDistanceup < 100f)
            //    {
            //       _Rigidbody.velocity = new Vector2(_Rigidbody.velocity.x, JumpForce);
            //   }
            //    else if (PilarDistanceup < 50f)
            //    {

            //   }
            // }

           // if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Geraakt2, 1 << 10))
           // {
           //     PilarDistancedown = Geraakt2.distance;

           //     if (PilarDistancedown < 100f)
           //     {
                    
            //    }
           // }
           
            //if (player.transform.position.y < -30f || player.transform.position.y < -30f && PilarDistanceup == 0 || player.transform.position.y < -30f && PilarDistancedown == 0)
            //{
            //    _Rigidbody.velocity = new Vector2(_Rigidbody.velocity.x, JumpForce);
            //}
            if(PilarDistanceup >= player.transform.position.y)
            {
                if(PilarDistancedown >= player.transform.position.y)
                {
                _Rigidbody.velocity = new Vector2(_Rigidbody.velocity.x, JumpForce);
                }
            }
           
            //if (Input.GetMouseButton (0))  // if left mouse button pressed
			//{

				//_Rigidbody.velocity = new Vector2 (_Rigidbody.velocity.x,JumpForce); // Jump
			//}
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
				LastPosition = new Vector3 (transform.position.x+3,0,0);
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
