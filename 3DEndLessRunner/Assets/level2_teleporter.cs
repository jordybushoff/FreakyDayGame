using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2_teleporter : MonoBehaviour

{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager .LoadScene("Level2");
            PacManmove.leven = 4;
            PacManmove.Score = 0;
            Enemy.leven = 4;
        }
    }
}


