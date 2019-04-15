
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
	public int ZweefForce;
	public int Speed;

    public float PilarDistanceup;
    public float PilarDistancedown;
	//public float PilarDistancedown;
    public AudioClip JetPackAudio;



	public AudioClip DieAudio;
	public ParticleSystem SmokeParticle;

	void Awake()
	{


		//  I have used -200 gravity in this game
		Physics.gravity = new Vector3(0, -200f,0);  //-200f bepaald valsnelheid wanneer er niet wordt geklikt. Lijkt geen effect te hebben op afstanden en snelheid.

	}


	void Start () {     
        _Rigidbody = GetComponent <Rigidbody> ();
		_Animator  = GetComponent <Animator> ();
		_AudioSource = GetComponent <AudioSource> ();
		_GameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent <GameManager> ();
        trapup = GameObject.FindGameObjectWithTag("TrapUp");
        trapdown = GameObject.FindGameObjectWithTag("Trap");
		//trapdown = GameObject.FindGameObjectWithTag("Score");
    }


		
		
	
	void Update () {
		if (_GameManager.CurrentState == GameState.InGame) { //Zodra dit geldig is, voer het volgende uit:
			_AudioSource.clip = JetPackAudio; //Sound effect wanneer er gesprongen wordt
			if (_AudioSource.isPlaying == false)//Als het geluid niet afspeelt --->
				_AudioSource.Play ();// ---> Speel het geluid af.
			_Animator.SetBool ("InGame", true); //geeft een boolean value door aan een animatie controller
			GetCurrentPlayerState (PlayerStates.Live); // De game is in de live state.
		}


		if (CurrentPlayerState == PlayerStates.Live) {

			player = GameObject.FindGameObjectWithTag ("Player");
			_Rigidbody.velocity = new Vector2 (Speed, _Rigidbody.velocity.y); // Speed

			RaycastHit Geraakt1;
			//RaycastHit Geraakt2;
			//RaycastHit Geraakt2;

			if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out Geraakt1)) {
				PilarDistanceup = Geraakt1.distance;
				//PilarDistanceup = trapup.gameObject.transform.position.x;
				//PilarDistancedown = Geraakt2.distance;
				//PilarDistancedown = Geraakt2.distance;

				if (PilarDistanceup < 60f) {
					_Rigidbody.velocity = new Vector2 (_Rigidbody.velocity.x, JumpForce);
				}
				//else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Geraakt2))
               // {

              // }

				else if (PilarDistanceup > 30f) {
					//_Rigidbody.velocity = new Vector2(_Rigidbody.velocity.x, ZweefForce);
				}


			}



			// if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Geraakt2, 1 << 10))
			// {
			//     PilarDistancedown = Geraakt2.distance;

			//     if (PilarDistancedown < 100f)
			//     {
                    
			//    }
			// }

			if (player.transform.position.y < -80f || player.transform.position.y < -80f && PilarDistancedown == 0 || player.transform.position.y < -80f && PilarDistancedown == 0) {
				_Rigidbody.velocity = new Vector2 (_Rigidbody.velocity.x, JumpForce);
			}

			if (CurrentPlayerState == PlayerStates.Live) { //wanneer de huidige player state live is, voer het volgende uit:

				_Rigidbody.velocity = new Vector2 (Speed, _Rigidbody.velocity.y); //Snelheid van de physics (verticale jump physics?)

				if (Input.GetMouseButton (0)) {  // Wanneer de linkermuis wordt geklikt --->


					_Rigidbody.velocity = new Vector2 (_Rigidbody.velocity.x, JumpForce); // ----> Spring
				}

				if (Input.GetMouseButtonDown (0)) {
					SmokeParticle.Play ();
				} else if (Input.GetMouseButtonUp (0)) {
					SmokeParticle.Stop ();
				}
				

			}
		}
	}


	void OnCollisionEnter(Collision Coll) //Wanneer er een collision met een trap plaatsvindt:
	{
		if (CurrentPlayerState == PlayerStates.Live) {
			if (Coll.gameObject.tag == "Trap") //W
			{
				LastPosition = new Vector3 (transform.position.x+3,0,0); // reset player naar de volgende positie
				GetCurrentPlayerState (PlayerStates.Die); //Verander player state naar, die
			}
		}

	}

	void OnTriggerEnter(Collider other) //wanneer de speler succesvol door een trap springt (???)
	{
		if (CurrentPlayerState == PlayerStates.Live) {
			if (other.tag == "Score") 
			{
				_GameManager.GetScore (1); //Tel 1 puntje er bij
			}
		}

	}
	//
	public void GetCurrentPlayerState (PlayerStates State)
	{
		CurrentPlayerState = State; //GetState
		Refresh ();
	}

	void Refresh(){
		switch (CurrentPlayerState)
		{
		case PlayerStates.Ready: //Wanneer de state, ready is
			{
				transform.position = LastPosition; //(Default positie?)
				transform.rotation = Quaternion.Euler (0,0,0); // returned een rotatie die Z graden roteerd om de Z As, X graden om de X as en y graden om de y as.
				_Rigidbody .velocity = new Vector3 (0,0,0); // Velocity geven aan de de rigidbody
				_Rigidbody.useGravity = false; // bepaalt of gravity de rigidbody affects, wanneer op false, gedraagt de rigidbody alsof hij in de ruimte zweeft
				_Rigidbody.freezeRotation = true; // bepaalt of physics de rotatie van het object beinvloeden
			}
			break;
		case PlayerStates.Live: // als state live is
			{
				_Rigidbody.useGravity = true; // zorgt ervoor dat gravity actief wordt en de rigidbody daarmee beinvloed.
			}
			break;
		case PlayerStates.Die: // als state die is
			{
				_Rigidbody.freezeRotation = false; //physics beinvloeden de rotatie van het object niet meer
				_AudioSource.PlayOneShot (DieAudio); //speel audio effect af wanneer de state die is.
				_Rigidbody.velocity = new Vector3 (0,0,0); //Velocity geven aan de rigidbody (Andere waarden dan de standaardwaarden kunnen onverwachtse effecten geven)
				_GameManager.GetCurrentState (GameState.EndGame); //Ga naar endgame state.
			}
			break;
		} 
	}
}
