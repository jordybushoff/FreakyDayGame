using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	public int Xpos;

	Player _player;
	GameManager _GameManager;
	Animator _Animator;

	void Start () {
		_Animator = GetComponent <Animator > ();
	
		_player = GameObject.FindGameObjectWithTag ("Player").GetComponent <Player> ();
		_GameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent <GameManager> ();
	}
	
	 
	void Update () {

		if (_GameManager.CurrentState == GameState.Ready) {
			_Animator.SetBool ("InGame", true);
		}

		if ( _player .CurrentPlayerState == PlayerStates2.Live || _player .CurrentPlayerState == PlayerStates2.Ready) {
			transform.position = new Vector3 (_player.transform.position.x + Xpos, transform.position.y, -250);
		}
	
	}


}
