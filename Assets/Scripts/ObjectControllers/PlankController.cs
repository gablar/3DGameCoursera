using UnityEngine;
using System.Collections;

public class PlankController : MonoBehaviour {

    Vector3 initialPosition;
    Quaternion initialRotation;
    public float min;
    public float max;
    private Vector3 flyDirection;
    public bool isBroken = false;
    Rigidbody rgb;
    // Use this for initialization
    void Start () {
        initialPosition = gameObject.transform.position;
        initialRotation = gameObject.transform.rotation;

        rgb = GetComponent<Rigidbody>();

        //selection
        rend = GetComponent<Renderer>();
        origColor = rend.material.color;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void ResetPlank()
    {
        gameObject.transform.position = initialPosition;
        gameObject.transform.rotation = initialRotation;
        isBroken = false;
    }

    private void EarthquakeEvent(){
        if (!isBroken) {
            isBroken = true;
            CalculateFlight();
            rgb.AddForce(flyDirection);
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

    void OnEnable()
    {
        TerrainController.OnEarthquake += EarthquakeEvent;
    }


    void OnDisable()
    {
        TerrainController.OnEarthquake -= EarthquakeEvent;
    }

    //selection

    Renderer rend;
    public bool selected;
    private Color startcolor;
    private Color origColor;
    void OnMouseEnter()
    {
        startcolor = rend.material.color;
        rend.material.color = Color.yellow;
    }
    void OnMouseExit()
    {
        rend.material.color = startcolor;
    }

    void OnMouseDown()
    {
        if (selected)
        {
            Deselect();
        }
        else {
            Select();
        }
    }

    public void Deselect()
    {
        rend.material.color = origColor;
        startcolor = origColor;
        selected = false;
    }

    void Select()
    {
        rend.material.color = Color.blue;
        startcolor = Color.blue;
        selected = true;
    }
}
