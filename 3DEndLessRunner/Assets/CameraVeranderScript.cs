using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVeranderScript : MonoBehaviour
{

    public Camera normalCamera;
    public Camera rampCamera;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    void Start()
    {
        rampCamera.enabled = false;
        normalCamera.enabled = true;
    }
        public void OnTriggerEnter(Collider other)
        {
            //When the player gets close enough (into this trigger's volume)
            //then we turn on the ramp Camera and temporarily turn off the normal one
            if (other.gameObject.tag == "Player")
            {
                SwitchToRampCamera();
                enemy1 = GameObject.FindGameObjectWithTag("Enemy");
                enemy2 = GameObject.FindGameObjectWithTag("Enemy2");
                enemy3 = GameObject.FindGameObjectWithTag("Enemy3");
                enemy4 = GameObject.FindGameObjectWithTag("Enemy4");
                Destroy(enemy1);
                Destroy(enemy2);
                Destroy(enemy3);
                Destroy(enemy4);
        }
    }

        public void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                SwitchToNormalCamera();
            }
        }

        private void SwitchToRampCamera()
        {
            rampCamera.enabled = true;
            normalCamera.enabled = false;
        }

        private void SwitchToNormalCamera()
        {
            rampCamera.enabled = false;
            normalCamera.enabled = true;
        }
}

    //enemy1 = GameObject.FindGameObjectWithTag("Enemy");
    //enemy2 = GameObject.FindGameObjectWithTag("Enemy2");
    //enemy3 = GameObject.FindGameObjectWithTag("Enemy3");
    //enemy4 = GameObject.FindGameObjectWithTag("Enemy4");
    //Destroy(enemy1);
    //Destroy(enemy2);
    //Destroy(enemy3);
    //Destroy(enemy4);

    

