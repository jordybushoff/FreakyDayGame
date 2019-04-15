using UnityEngine;
using System.Collections;
using UnityEngine .SceneManagement;
using UnityEngine .UI;
public enum GameState{
	
	Start,
	Ready,
	InGame,
	EndGame,
	PouseGame,
	Continiue	
}
public class GameManager : MonoBehaviour {
	public GameState CurrentState = GameState.Start;
	 
	int Score;
	Player _Player;
	public Text TxtScore, TxtScoreGameOver, TxtBestScore,TxtCounter;
	public GameObject UiInGame;
	public GameObject BtnStart;
	public Animator _AnimCanvas;

	void Start(){
		_Player = GameObject.FindGameObjectWithTag ("Player").GetComponent <Player> ();
		Refresh (); 
	}


	//Get Current State Game
	public void GetCurrentState (GameState State){
		CurrentState = State;
		Refresh ();
	}


	public void Refresh(){
		switch (CurrentState) {
		 
		case GameState.InGame:
			{
				Time.timeScale = 1;
				UiInGame.SetActive (true);

			}
			break;

		case GameState.Ready:
			{
				
				StartCoroutine ("GoToInGame");
			 
			}
			break;
		case GameState.EndGame:
			{

				if (Score > PlayerPrefs.GetInt ("BestScore")) {
					PlayerPrefs.SetInt ("BestScore", Score);
				}


				UiInGame.SetActive (false);
				TxtScoreGameOver.text = "" + Score;
				TxtBestScore.text = "" + PlayerPrefs.GetInt ("BestScore");
				_AnimCanvas.SetBool ("EndGame",true);
				 
			}
			break;

		

		}
	}

	public IEnumerator GoToInGame(){
		yield return new WaitForSeconds (1f);
		GetCurrentState (GameState.InGame);


	}

	public IEnumerator ContinueGame(){
		 
		_AnimCanvas.SetBool ("EndGame",false);
		_Player.GetCurrentPlayerState (PlayerStates.Ready);
		yield return new WaitForSeconds (1f);
		TxtCounter.text = "" + 3;
		yield return new WaitForSeconds (1f);
		TxtCounter.text = "" + 2;
		yield return new WaitForSeconds (1f);
		TxtCounter.text = "" + 1;
		yield return new WaitForSeconds (1f);
		TxtCounter.text = "";

		GetCurrentState (GameState.InGame);

	}

	public void StartGame(){
		GetCurrentState (GameState.Ready);
		BtnStart.SetActive (false);
	}

	public void Btn_Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		//GetCurrentState (GameState.Ready);
	}

	public void Btn_Continiue(){
		StartCoroutine ("ContinueGame");
	}

	public void GetScore(int NewScore){
		Score += NewScore;
		TxtScore.text = "" + Score;
	}
}
