using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
	public Transform sun, moon;

	[SerializeField] int distanceFromOrigin = 10;
	[SerializeField] float daySpeed = .1f;

	[SerializeField] int orbitAngle;
	[SerializeField] int sunrisePostion;
	[SerializeField] int dayProgress;

    // Start is called before the first frame update
    void Start()
    {
		SetUpOrbitals ();
		SetOrbitalPath ();
    }

	void SetUpOrbitals()
	{
		Vector3 distanceFromOriginVector = new Vector3(distanceFromOrigin, 0, 0);

		sun.position = -distanceFromOriginVector;
		moon.position = distanceFromOriginVector;

		sun.rotation = Quaternion.Euler (0, -90, 0);
		moon.rotation = Quaternion.Euler (0, 90, 0);

	}

	void SetOrbitalPath()
	{
		transform.rotation = Quaternion.Euler (orbitAngle, sunrisePostion, dayProgress);
	}

	void FixedUpdate()
	{
		transform.Rotate (0, 0, daySpeed);
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
