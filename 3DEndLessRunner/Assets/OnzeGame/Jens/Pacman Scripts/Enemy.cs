using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    NavMeshAgent agent;
    float Speed = 3f;
    float currenttime = 0f;
    float starttime = 3f;
    static int leven = 3;     
   
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
    }

    // Update is called once per frame
    void Update()
    {
        currenttime -= 1 * Time.deltaTime;      

        if (currenttime <= 0)
        {
            agent.speed = Speed;
            agent.destination = target.transform.position;
        }

        if (leven <= 0)
        {
            Speed = 0f;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Pacman jens");
            leven--;

            /*enemy1.transform.position = new Vector3(4.545066f, 0.92f, 9.965279f);
            enemy2.transform.position = new Vector3(-13.40629f, 0.92f, 10.05341f);
            enemy3.transform.position = new Vector3(4.493049f, 0.92f, -7.914293f);
            enemy4.transform.position = new Vector3(-13.3047f, 0.92f, -8.012804f);
            target.transform.position = new Vector3(0.15f, 0.767f, 1.924f);*/
        }         
    }
}
