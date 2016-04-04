using UnityEngine;
using System.Collections;

public class ForgeController : MonoBehaviour {
    public delegate void ForgeActivada();
    public static event ForgeActivada OnForgeActivada;
    // Use this for initialization

   
    float t;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Log") {
            Debug.Log("Log collided with Forge");
            if (OnForgeActivada != null) {
                OnForgeActivada();
            }
        }
    }
}
