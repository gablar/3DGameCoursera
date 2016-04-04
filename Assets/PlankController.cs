using UnityEngine;
using System.Collections;

public class PlankController : MonoBehaviour {

    Vector3 initialPosition;
    Quaternion initialRotation;
    public float min;
    public float max;
    private Vector3 flyDirection;
    private GameManager gameManager = null;
    public bool isBroken = false;
    public bool montar = false;
    Rigidbody rgb;
    // Use this for initialization
    void Start () {
        initialPosition = gameObject.transform.position;
        initialRotation = gameObject.transform.rotation;

        rgb = GetComponent<Rigidbody>();
        GameObject g = GameObject.Find("GameManager");
        if (g != null)
        {
            gameManager = g.GetComponent<GameManager>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (gameManager.yaHuboEarthquake && !isBroken) {
            isBroken = true;
            CalculateFlight();
            rgb.AddForce(flyDirection);
            Debug.Log("force added to log");
        }

        if (montar) {
            gameObject.transform.position = initialPosition;
            gameObject.transform.rotation = initialRotation;
            montar = false;
        }
	}

    void CalculateFlight()
    {
        float x = Random.Range(min, max);
        if (Random.value >= 0.5f)
        {
            x *= -1;
        }

        float z = Random.Range(min, max);
        if (Random.value >= 0.5f)
        {
            z *= -1;
        }
        float y = Random.Range(5 * min, 5 * max);
        flyDirection = new Vector3(x, y, z);
    }
}
