using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVeranderScript : MonoBehaviour
{
    public Camera firstperson;
    public Camera normalCamera;
    // Start is called before the first frame update
    void Start()
    {
        normalCamera.enabled = true;
        firstperson.enabled = false;
    }
   
    // Update is called once per frame
    void Update()
    {
        void OnCollisionEnter(Collision collision)
        {
            normalCamera.enabled = false;
            firstperson.enabled = true;
        }
        void OnCollisionExit(Collision collision)
        {
            normalCamera.enabled = true;
            firstperson.enabled = false;
        }
        //if (collision.gameObject.tag == "Player")
        //{
        //    enemy1 = GameObject.FindGameObjectWithTag("Enemy");
        //    enemy2 = GameObject.FindGameObjectWithTag("Enemy2");
        //    enemy3 = GameObject.FindGameObjectWithTag("Enemy3");
        //    enemy4 = GameObject.FindGameObjectWithTag("Enemy4");
        //    Destroy(enemy1);
        //    Destroy(enemy2);
        //    Destroy(enemy3);
        //    Destroy(enemy4);
        //}
    }
}
