using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ghost3 : MonoBehaviour
{
    public GameObject target;
    public GameObject enemy3;
    public GameObject spawn3;
    NavMeshAgent agent;
    public float Speed = 3f;
    public bool clone = false;
    public float currenttime = 0f;
    public float starttime = 3f;
    public float powercurrent = 0;
    public bool powerup = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currenttime = starttime;

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemy3 = GameObject.FindGameObjectWithTag("Enemy3");
        currenttime -= 1 * Time.deltaTime;
        if (currenttime <= 0 && powerup == false)
        {
            agent.speed = Speed;
            agent.destination = target.transform.position;
        }

        if (powerup == true)
        {
            powercurrent -= 1 * Time.deltaTime;
            agent.destination = -target.transform.position;
            //Fetch the Renderer from the GameObject
            Renderer rend = GetComponent<Renderer>();

            //Set the main Color of the Material to green
            rend.material.shader = Shader.Find("_Color");
            rend.material.SetColor("_Color", Color.blue);
            if (powercurrent <= 0)
            {
                powerup = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PacManmove>().check = false;               
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && powerup == true)
        {
            Destroy(enemy3);
            if (!clone)
            {
                GameObject go = (GameObject)(Instantiate(enemy3, new Vector3(0.42f, 0.75f, -0.01f), Quaternion.identity));
                GameObject.FindGameObjectWithTag("Player").GetComponent<PacManmove>().currenttime2 += 10f;
                go.GetComponent<NavMeshAgent>().enabled = true;
                go.GetComponent<Ghost3>().enabled = true;
                clone = true;
            }
            else
            {
                clone = false;
            }
        }
    }
}
