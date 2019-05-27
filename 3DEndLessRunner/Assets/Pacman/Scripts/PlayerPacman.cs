using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPacman1 : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //moveSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0.0f, 0.0f, moveSpeed * Time.deltaTime);
        }
    }
}
