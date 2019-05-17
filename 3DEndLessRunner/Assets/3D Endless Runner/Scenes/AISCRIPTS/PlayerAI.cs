//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class PlayerAI : MonoBehaviour
//{
//    Player bird = new Player();
//
//    GameObject pipes = GameObject.FindGameObjectWithTag("Trap");
//    int score = 0;
//    List<bird> gen = new List<bird>();
//    int alives = 0;
//    int generation = 0;
//    int maxscore = 0;
//    var Neuvol;
//
//    // Start is called before the first frame update
//    void Start()
//    {
//
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//
//    }
//    public void gamestart()
//    {
//
//
//        this.birds = new List<bird>();
//
//        this.gen = Neuvol.nextGeneration();
//
//        foreach (var i in this.gen)
//        {
//            var b = new bird();
//            birds.items.add(b);
//
//        }
//        this.generation++;
//        this.alives = this.birds.length;
//    }
//    public void ReturnGenValue()
//    {
//        this.birds[i].update();
//        if (this.birds[i].isDead(this.height, this.pipes))
//        {
//            this.birds[i].alive = false;
//            this.alives--;
//            //console.log(this.alives);
//            Neuvol.networkScore(this.gen[i], this.score);
//            if (this.isItEnd())
//            {
//                this.start();
//            }
//            if (Player.isDead == true)
//            {
//
//            }
//        }
//    }
//}