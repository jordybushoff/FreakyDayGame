/*using UnityEngine;
using System.Collections;

public class MaterialOffset : MonoBehaviour {
	Renderer _Renderer;
	GameManager _GameManager;

	float OffsetPlus;
	public float Speed;

	void Start () {
		_Renderer = GetComponent <Renderer> ();
		_GameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent <GameManager> ();
	}
	

	void Update () {
		if (_GameManager.CurrentState == GameState.InGame)
		OffsetPlus += Speed * Time.deltaTime;
		
		_Renderer .material.mainTextureOffset = new Vector2 (OffsetPlus,_Renderer.material.mainTextureOffset.y);
	}
}
*/