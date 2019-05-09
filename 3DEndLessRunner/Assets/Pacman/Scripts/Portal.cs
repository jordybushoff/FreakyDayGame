using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		other.gameObject.transform.position = spawnPoint.position;
		GetComponent<AudioSource>().PlayOneShot(TeleportSound);
	}

    // Update is called once per frame
    void Update()
    {
		transform.Rotate (0, speed, 0);
    }
}
