﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy1 : MonoBehaviour
{

	public GameObject target;
	NavMeshAgent agent;
	public int Speed;

    // Start is called before the first frame update
    void Start()
    {
		agent = GetComponent<NavMeshAgent>();
		agent.speed = Speed;
		if (target == null)
			target = GameObject.FindGameObjectWithTag ("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
		agent.destination = target.transform.position;
    }

	public void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Player")
		SceneManager.LoadScene("OefenScenePacman");
	}
}