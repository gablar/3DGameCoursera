using UnityEngine;
using System.Collections;

public class SawmillController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Tree")) {
            Destroy(other.gameObject, 1);
        }
    }
}
