using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacManmove : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody playerRb;
    private Transform playerRotation;
    public AudioSource MovementPackman;
	public AudioSource SnoepGeluid;

    public static int Score = 0;
    public static int leven = 3;
    float currenttime = 0f;
    public float currenttime2 = 0f;
    float starttime2 = 180f;
    float starttime = 3f;
    float speedcurrent = 0f;
    float speedstart = 5f;

    bool timer = true;
    bool tijdenable = false;
    public bool check = false;
    bool snelpower = false;
    public Text ScoreText;
    public Text tijd;
    public Text Finalscore;
    public GameObject pacman;
    public GameObject food;
    public GameObject power;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject steen;
    public GameObject sneller;
    public AudioSource DeathSound;

    // Use this for initialization
    void Awake()
    {
        playerRotation = GetComponent<Transform>();
        playerRb = GetComponent<Rigidbody>();
        pacman = GameObject.FindGameObjectWithTag("Player");
        enemy1 = GameObject.FindGameObjectWithTag("Enemy");
        enemy2 = GameObject.FindGameObjectWithTag("Enemy2");
        enemy3 = GameObject.FindGameObjectWithTag("Enemy3");
        enemy4 = GameObject.FindGameObjectWithTag("Enemy4");
        spawn1 = GameObject.FindGameObjectWithTag("Spawn1");
        spawn2 = GameObject.FindGameObjectWithTag("Spawn2");
        spawn3 = GameObject.FindGameObjectWithTag("Spawn3");
        spawn4 = GameObject.FindGameObjectWithTag("Spawn4");
        steen = GameObject.FindGameObjectWithTag("Finish");
        sneller = GameObject.FindGameObjectWithTag("SnellerSnoep");

        currenttime2 = starttime2;
        currenttime = starttime;       
        tijd.text = currenttime2.ToString("0");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ContinuousMovement();
    }

    void Update()
    {
        if (timer == true)
        {
            moveSpeed = 0f;
            MovementPackman.Stop ();

            currenttime -= 1 * Time.deltaTime;
            ScoreText.text = currenttime.ToString("0");
            if (ScoreText.text == "0")
            {
                ScoreText.text = "Go!";
            }
            if (currenttime <= 0)
            {
                timer = false;
                tijdenable = true;
            }
        }

        if (timer == false)
        {
            SetScoreText();
            moveSpeed = 4f;
        }

        if (tijdenable == true)
        {
            currenttime2 -= 1 * Time.deltaTime;
            tijd.text = currenttime2.ToString("0");
        }

        if (snelpower == true)
        {           
            moveSpeed = 6f;
            speedcurrent -= 1 * Time.deltaTime;

            if (speedcurrent <= 0)
            {
                snelpower = false;
            }
        }

        MoveRotation();
        if (leven <= 0)
        {
            //GameObject.Find("RestartButton").transform.localScale = new Vector3(1, 1, 1);
            food = GameObject.FindGameObjectWithTag("Eten");
            power = GameObject.FindGameObjectWithTag("Destroyer");
            Destroy(food);
            Destroy(power);
            ScoreText.text = "Defeat!";
            tijdenable = false;
            currenttime2 = 0f;
            tijd.text = currenttime2.ToString();
            moveSpeed = 0f;
			MovementPackman.Stop ();
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Ghost1>().Speed = 0;
            GameObject.FindGameObjectWithTag("Enemy2").GetComponent<Ghost2>().Speed = 0;
            GameObject.FindGameObjectWithTag("Enemy3").GetComponent<Ghost3>().Speed = 0;
            GameObject.FindGameObjectWithTag("Enemy4").GetComponent<Ghost4>().Speed = 0;
        }
        if (leven >= 1)
        {
           // GameObject.Find("RestartButton").transform.localScale = new Vector3(0, 0, 0);
        }
    }

    public void ContinuousMovement()
    {
        playerRb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);
    }

    public void scorecount()
    {
        if (currenttime2 > 0)
        {
            currenttime2--;
            tijd.text = currenttime2.ToString("0");
            Score++;
            Finalscore.text = "Finalscore: " + Score.ToString();
        }
        else if (tijd.text == "-1")
        {
            tijd.text = "0";
        }
    }

    void MoveRotation()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovementPackman.Play();
            playerRotation.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            MovementPackman.Play();
            playerRotation.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            MovementPackman.Play();
            playerRotation.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        if (Input.GetKeyDown (KeyCode.RightArrow)) {
			MovementPackman.Play ();
			playerRotation.rotation = Quaternion.Euler (0f, 90f, 0f);
		} 					
   	}
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Eten")
        {
            Score++;
			SnoepGeluid.Play();
            SetScoreText();
        }
        if (collision.gameObject.tag == "SnellerSnoep")
        {
            Score++;
            SnoepGeluid.Play();
            SetScoreText();
            speedcurrent = speedstart;
            snelpower = true;
        }
        if (collision.gameObject.tag == "Destroyer")
        {
            Score++;
            SnoepGeluid.Play();
            SetScoreText();
            check = true;
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Ghost1>().powerup = true;
            GameObject.FindGameObjectWithTag("Enemy2").GetComponent<Ghost2>().powerup = true;
            GameObject.FindGameObjectWithTag("Enemy3").GetComponent<Ghost3>().powerup = true;
            GameObject.FindGameObjectWithTag("Enemy4").GetComponent<Ghost4>().powerup = true;
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Ghost1>().powercurrent = 7f;
            GameObject.FindGameObjectWithTag("Enemy2").GetComponent<Ghost2>().powercurrent = 7f;
            GameObject.FindGameObjectWithTag("Enemy3").GetComponent<Ghost3>().powercurrent = 7f;
            GameObject.FindGameObjectWithTag("Enemy4").GetComponent<Ghost4>().powercurrent = 7f;
        }
        if (collision.gameObject.tag == "Enemy2" && leven >= 1 && check == false || collision.gameObject.tag == "Enemy" && leven >= 1 && check == false || collision.gameObject.tag == "Enemy3" && leven >= 1 && check == false || collision.gameObject.tag == "Enemy4" && leven >= 1 && check == false)
        {           
            snelpower = false;
            currenttime2 -= 20f;
            currenttime = starttime;
            timer = true;
            leven--;
            enemyrespawn();            
            DeathSound.Play();

            if (leven == 3)
            {
                GameObject.Find("heart (1)").transform.localScale = new Vector3(0, 0, 0);
            }

            if (leven == 2)
            {
                GameObject.Find("heart (2)").transform.localScale = new Vector3(0, 0, 0);
            }

            if (leven == 1)
            {
                GameObject.Find("heart (3)").transform.localScale = new Vector3(0, 0, 0);
                leven--;
            }

            if (leven == 4)
            {
                GameObject.Find("heart (1)").transform.localScale = new Vector3(1, 1, 1);

                GameObject.Find("heart (2)").transform.localScale = new Vector3(1, 1, 1);

                GameObject.Find("heart (3)").transform.localScale = new Vector3(1, 1, 1);
            }
        }      
    }

    public void SetScoreText()
    {
        ScoreText.text = "Score: " + Score.ToString();
        if (Score >= 5)
        {
            tijdenable = false;
            ScoreText.text = "";
            scorecount();           
            Destroy(enemy1);
            Destroy(enemy2);
            Destroy(enemy3);
            Destroy(enemy4);
            Destroy(steen);
        }
    }

    public void enemyrespawn()
    {
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Ghost1>().enemy1.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GameObject.FindGameObjectWithTag("Enemy2").GetComponent<Ghost2>().enemy2.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GameObject.FindGameObjectWithTag("Enemy3").GetComponent<Ghost3>().enemy3.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GameObject.FindGameObjectWithTag("Enemy4").GetComponent<Ghost4>().enemy4.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Ghost1>().enemy1.transform.position = spawn1.transform.position;
        GameObject.FindGameObjectWithTag("Enemy2").GetComponent<Ghost2>().enemy2.transform.position = spawn2.transform.position;
        GameObject.FindGameObjectWithTag("Enemy3").GetComponent<Ghost3>().enemy3.transform.position = spawn3.transform.position;
        GameObject.FindGameObjectWithTag("Enemy4").GetComponent<Ghost4>().enemy4.transform.position = spawn4.transform.position;
        pacman.transform.position = new Vector3(0.15f, 0.767f, 1.924f);

        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Ghost1>().enemy1.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        GameObject.FindGameObjectWithTag("Enemy2").GetComponent<Ghost2>().enemy2.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        GameObject.FindGameObjectWithTag("Enemy3").GetComponent<Ghost3>().enemy3.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        GameObject.FindGameObjectWithTag("Enemy4").GetComponent<Ghost4>().enemy4.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;

        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Ghost1>().currenttime = starttime;
        GameObject.FindGameObjectWithTag("Enemy2").GetComponent<Ghost2>().currenttime = starttime;
        GameObject.FindGameObjectWithTag("Enemy3").GetComponent<Ghost3>().currenttime = starttime;
        GameObject.FindGameObjectWithTag("Enemy4").GetComponent<Ghost4>().currenttime = starttime;
    }
}
