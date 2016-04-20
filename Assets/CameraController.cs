using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public float scrollMultiplier = 1;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right * Input.GetAxis("Mouse ScrollWheel")*scrollMultiplier*Time.deltaTime);
    }
}
