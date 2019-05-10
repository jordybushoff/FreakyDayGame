using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy1 : MonoBehaviour
{

    public GameObject target;
    NavMeshAgent agent;
    public int Speed;
    bool startTimer = false;
    public float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Speed;
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
        agent.destination = target.transform.position;
    }


    public void OnCollisionEnter(Collision collision)
    {
       //  SoundManagerScript.PlaySound("pacman_death");       
        
        if (collision.gameObject.tag == "Player")
        {
            startTimer = true;
        }

        if (startTimer == true)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > 1f)
            {
                SceneManager.LoadScene("OefenScenePacman");
            }
        }

    }

    

}
