using UnityEngine;
using System.Collections;

public class MillController : MonoBehaviour {

    public float speed = 50.0f;
    public bool millActivated = false;


    void Update()
    {
        transform.Rotate(0,0,speed);
    }
}
