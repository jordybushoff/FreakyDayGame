using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacManmove : MonoBehaviour
{
    public float moveSpeed = 7f;

    private Rigidbody playerRb;
    private Transform playerRotation;
    public AudioSource MovementPackman;
    public static int Score = 0;
    public static int leven = 3;
    float currenttime = 0f;
    float starttime = 3f;
    bool timer = true;
    public Text ScoreText;
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
        currenttime = starttime;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        ContinuousMovement();
    }

    void Update()
    {
        currenttime -= 1 * Time.deltaTime;

        MoveRotation();
        if (leven <= 0)
        {
            food = GameObject.FindGameObjectWithTag("Eten");
            Destroy(food);
            ScoreText.text = "Defeat!";          
            moveSpeed = 0f;
        }
    }

    public void ContinuousMovement()
    {
        playerRb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);
    }
    void MoveRotation()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //MovementPackman.Play();
            playerRotation.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            //MovementPackman.Play();
            playerRotation.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            //MovementPackman.Play();
            playerRotation.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //MovementPackman.Play();
            playerRotation.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Eten")
        {
            Score++;
            SetScoreText();
        }
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Enemy3" || collision.gameObject.tag == "Enemy4" && leven >= 1)
        {
            leven--;
        }      
    }

    public void SetScoreText()
    {
        ScoreText.text = "Score: " + Score.ToString();
        if (Score >= 179)
        {
            ScoreText.text = "Victory!";
            Destroy(enemy1);
            Destroy(enemy2);
            Destroy(enemy3);
            Destroy(enemy4);
        }
    }
}