using UnityEngine;
using System.Collections;
using System;

public class MillController : MonoBehaviour {

    public float rotation= 25.0f;
    public float flyspeed = 50;
    bool resetBlade = true;
    public float min;
    public float max;
    AudioSource sawSound;




    Rigidbody rgb;
    Vector3 bladePosition;
    Quaternion bladeRotation;
    Vector3 flyDirection;

    

    void Start() {
        rgb = GetComponent<Rigidbody>();
        bladePosition = transform.position;
        bladeRotation = transform.rotation;
        sawSound = GetComponent<AudioSource>();
        
        //selection 
        rend = GetComponent<Renderer>();
        origColor = rend.material.color;
    }
    void Update()
    {
      
    }

    public void DeactivateMill()
    {
        rgb.angularVelocity = new Vector3(0,0,0);
        sawSound.Stop();
    }

    public void ActivateMill() {
        if (resetBlade) {
            rgb.angularVelocity = new Vector3(0, 0, rotation);
            //rgb.AddTorque(new Vector3(0, 0, rotation));
            sawSound.Play();
        }
    }

    void CalculateFlight() {
        float x = UnityEngine.Random.Range(min,max);
        if (UnityEngine.Random.value >= 0.5f) {
            x *= -1;
        }

        float z = UnityEngine.Random.Range(min, max);
        if (UnityEngine.Random.value >= 0.5f)
        {
            z *= -1;
        }
        float y = UnityEngine.Random.Range(5*min, 5*max);
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
            DeactivateMill();
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
