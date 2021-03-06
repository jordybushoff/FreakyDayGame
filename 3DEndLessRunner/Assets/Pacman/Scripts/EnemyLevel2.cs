﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyLevel2 : MonoBehaviour
{
	public GameObject target;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
	public GameObject spawn1;
	public GameObject spawn2;
	public GameObject spawn3;
	public GameObject spawn4;

	public GameObject Player;

	public GameObject spawnPacman;
	NavMeshAgent agent;
	public float Speed = 3f;
	
	public float currenttime = 0f;
	public float starttime = 3f;
	public float powercurrent = 0;
	public static int leven = 3;
	public bool powerup = false;
	
	public AudioSource DeathSound;
	
	// Start is called before the first frame update
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		currenttime = starttime;
		
		if (target == null)
		{
			target = GameObject.FindGameObjectWithTag("Player");
		}
		enemy1 = GameObject.FindGameObjectWithTag("Enemy");
		enemy2 = GameObject.FindGameObjectWithTag("Enemy2");
		enemy3 = GameObject.FindGameObjectWithTag("Enemy3");
		enemy4 = GameObject.FindGameObjectWithTag("Enemy4");
		spawn1 = GameObject.FindGameObjectWithTag("Spawn1");
		spawn2 = GameObject.FindGameObjectWithTag("Spawn2");
		spawn3 = GameObject.FindGameObjectWithTag("Spawn3");
		spawn4 = GameObject.FindGameObjectWithTag("Spawn4");
	}
	
	// Update is called once per frame
	void Update()
	{
		currenttime -= 1 * Time.deltaTime;
		//manier voor currenttime starttime op te lossen bedenken
		if (currenttime <= 0 && powerup == false )
		{            
			agent.speed = Speed;
			agent.destination = target.transform.position;      
		}      
		
		if (leven <= 0)
		{
			Speed = 0f;
		} 
		
		if (powerup == true)
		{
			powercurrent -= 1 * Time.deltaTime;
			agent.destination = -target.transform.position;
			if (powercurrent <= 0)
			{
				powerup = false;
				GameObject.FindGameObjectWithTag("Player").GetComponent<PacManmove>().check = false;
			}
		}        
	}
	
	public void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player" && powerup == false)
		{
			leven--;
			DeathSound.Play();
			
			enemy1.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
			enemy2.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
			enemy3.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
			enemy4.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
			
			enemy1.transform.position = spawn1.transform.position;
			enemy2.transform.position = spawn2.transform.position;
			enemy3.transform.position = spawn3.transform.position;
			enemy4.transform.position = spawn4.transform.position;
			Player.transform.position = spawnPacman.transform.position;



			
			enemy1.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
			enemy2.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
			enemy3.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
			enemy4.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;              
		}
		if (collision.gameObject.tag == "Player" && powerup == true)
		{
			transform.position = spawn1.transform.position;
			GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
			GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
			GameObject.FindGameObjectWithTag("Player").GetComponent<PacManmove>().currenttime2 += 10f;
		}
	}
}

