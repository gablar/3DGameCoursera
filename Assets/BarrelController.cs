using UnityEngine;
using System.Collections;
using System;

public class BarrelController : MonoBehaviour {
    public bool inPosition = true;
    Vector3 initialPosition;
    Quaternion initialRotation;

    Rigidbody rgb;
    public float min;
    public float max;
    Vector3 flyDirection;

    // Use this for initialization
    void Start () {
        rgb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ResetPosition()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        inPosition = true;
        rgb.constraints = RigidbodyConstraints.FreezeAll;

    }

    void CalculateFlight()
    {
        float x = UnityEngine.Random.Range(min, max);
        if (UnityEngine.Random.value >= 0.5f)
        {
            x *= -1;
        }

        float z = UnityEngine.Random.Range(min, max);
        if (UnityEngine.Random.value >= 0.5f)
        {
            z *= -1;
        }
        float y = UnityEngine.Random.Range(5 * min, 5 * max);
        flyDirection = new Vector3(x, y, z);
    }

    void OnEnable()
    {
        TerrainController.OnEarthquake += EarthquakeEvent;
    }


    void OnDisable()
    {
        TerrainController.OnEarthquake -= EarthquakeEvent;
    }

    private void EarthquakeEvent()
    {   if (inPosition)
        {
            rgb.constraints = RigidbodyConstraints.None;
            CalculateFlight();
            rgb.AddForce(flyDirection);
            inPosition = false;
        }
    }
}
