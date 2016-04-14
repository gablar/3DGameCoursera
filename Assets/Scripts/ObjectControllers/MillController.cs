using UnityEngine;
using System.Collections;

public class MillController : MonoBehaviour {

    public float rotation= 25.0f;
    public float flyspeed = 50;
    bool millActivated = false;
    bool resetBlade = true;
    public float min;
    public float max;




    Rigidbody rgb;
    Vector3 bladePosition;
    Quaternion bladeRotation;
    Vector3 flyDirection;

    

    void Start() {
        rgb = GetComponent<Rigidbody>();
        bladePosition = transform.position;
        bladeRotation = transform.rotation;
        
        //selection 
        rend = GetComponent<Renderer>();
        origColor = rend.material.color;
    }
    void Update()
    {  
        if (millActivated)
        {
            ActivateMill();
            //transform.Rotate(0, 0, speed);
        }
    }
    
    void ActivateMill() {
        rgb.AddTorque(new Vector3(0, 0, rotation));
    }

    void CalculateFlight() {
        float x = Random.Range(min,max);
        if (Random.value >= 0.5f) {
            x *= -1;
        }

        float z = Random.Range(min, max);
        if (Random.value >= 0.5f)
        {
            z *= -1;
        }
        float y = Random.Range(5*min, 5*max);
        flyDirection = new Vector3(x,y,z);
    }

    public void ResetBlade() {
        transform.position = bladePosition;
        transform.rotation = bladeRotation;
        resetBlade = true;
        rgb.constraints = RigidbodyConstraints.FreezePosition |
                            RigidbodyConstraints.FreezeRotationX | 
                            RigidbodyConstraints.FreezeRotationY;
    }


    private void EarthquakeEvent() {
        Debug.Log("earthquake registered");
        if (resetBlade) {
            resetBlade = false;
            millActivated = false;
            rgb.constraints = RigidbodyConstraints.None;
            CalculateFlight();
            rgb.AddForce(flyDirection);
        }
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

    public void Select()
    {
        rend.material.color = Color.blue;
        startcolor = Color.blue;
        selected = true;
    }
}
