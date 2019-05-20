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
    float currenttime2 = 0f;
    float starttime2 = 180f;
    float starttime = 3f;
    bool timer = true;
    bool tijdenable = false;
    public Text ScoreText;
    public Text tijd;
    public Text Finalscore;
    public GameObject food;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    // Use this for initialization
    void Awake()
    {
        playerRotation = GetComponent<Transform>();
        playerRb = GetComponent<Rigidbody>();              
        enemy1 = GameObject.FindGameObjectWithTag("Enemy");
        enemy2 = GameObject.FindGameObjectWithTag("Enemy2");
        enemy3 = GameObject.FindGameObjectWithTag("Enemy3");
        enemy4 = GameObject.FindGameObjectWithTag("Enemy4");
        
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

        MoveRotation();
        if (leven <= 0)
        {
            food = GameObject.FindGameObjectWithTag("Eten");
            Destroy(food);
            ScoreText.text = "Defeat!";
            tijdenable = false;
            currenttime2 = 0f;
            tijd.text = currenttime2.ToString();
            moveSpeed = 0f;
			MovementPackman.Stop ();
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
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Enemy3" || collision.gameObject.tag == "Enemy4" && leven >= 1)
        {
            leven--;
            currenttime = starttime;
            timer = true;
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().currenttime = starttime; 
            GameObject.FindGameObjectWithTag("Enemy2").GetComponent<Enemy>().currenttime = starttime; 
            GameObject.FindGameObjectWithTag("Enemy3").GetComponent<Enemy>().currenttime = starttime; 
            GameObject.FindGameObjectWithTag("Enemy4").GetComponent<Enemy>().currenttime = starttime; 
        }      
    }

    public void SetScoreText()
    {
        ScoreText.text = "Score: " + Score.ToString();
        if (Score >= 179)
        {
            tijdenable = false;           
            ScoreText.text = "";
            scorecount();
            moveSpeed = 0f;
            this.gameObject.transform.position = new Vector3(0.15f, 0.767f, 1.924f);
            Destroy(enemy1);
            Destroy(enemy2);
            Destroy(enemy3);
            Destroy(enemy4);
        }
    }
}