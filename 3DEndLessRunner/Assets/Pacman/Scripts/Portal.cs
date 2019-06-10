using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
	public Transform spawnPoint;
	public float speed = 5f;
	public AudioClip TeleportSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	void OnTriggerEnter(Collider other)
	{
        SceneManager.LoadScene("Level2.1");
    }

    // Update is called once per frame
    void Update()
    {
		transform.Rotate (0, speed, 0);
    }
}
