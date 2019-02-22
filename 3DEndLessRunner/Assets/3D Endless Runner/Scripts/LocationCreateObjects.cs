using UnityEngine;
using System.Collections;

public class LocationCreateObjects : MonoBehaviour {

	public GameObject [] Traps;

	float CurrentTime;
	float InstantiateTime;
	public float MinTime,MaxTime;
	GameManager _GameManager;

	void Start () 
	{
		SetTime ();
		_GameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent <GameManager> ();
	}
	
	 
	void Update () 
	{
		if (_GameManager.CurrentState == GameState.InGame) {


			CurrentTime += 1 * Time.deltaTime;

			if (CurrentTime >= InstantiateTime) {
				SetNumberOfTrap ();
				Instantiate (Traps[TrapNumber],transform.position,transform.rotation);
				SetTime ();
				CurrentTime = 0;
			}

		}
	}

	public void SetTime(){
		InstantiateTime = Random.Range (MinTime,MaxTime);
	}

	int TrapNumber;
	public void SetNumberOfTrap(){
		TrapNumber = Random.Range (0,Traps.Length);
	}
}
