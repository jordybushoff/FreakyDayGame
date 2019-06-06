using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour { 


    public void RestartGame()
    {     
        SceneManager.LoadScene("PACMANjordy");
        PacManmove.leven = 4;
        PacManmove.Score = 0;
        Enemy.leven = 4;        
    }
}
