using UnityEngine;
using System.Collections;

public class MillController : MonoBehaviour {

    public float rotation= 25.0f;
    public float flyspeed = 50;
    public bool millActivated = false;
    public bool resetBlade = false;
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
    }
    void Update()
    {   if (resetBlade) {
            ResetBlade();
        }

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

    void ResetBlade() {
        transform.position = bladePosition;
        transform.rotation = bladeRotation;
        resetBlade = false;
        rgb.constraints = RigidbodyConstraints.FreezePosition |
                            RigidbodyConstraints.FreezeRotationX | 
                            RigidbodyConstraints.FreezeRotationY;
    }


    public void EarthquakeEvent() {
        if (millActivated) { 
            millActivated = false;
            rgb.constraints = RigidbodyConstraints.None;
            CalculateFlight();
            rgb.AddForce(flyDirection);
        }
    }
}
