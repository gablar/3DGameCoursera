using UnityEngine;
using System.Collections;

public class WindBladeController : MonoBehaviour {
    Rigidbody rgb;
	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
       // rgb.AddTorque(500, 0, 0);
	}

    void OnEnable() {
        ForgeController.OnForgeActivada += ForgeActivada;
    }

    void OnDisable()
    {
        ForgeController.OnForgeActivada -= ForgeActivada;
    }

    public void ForgeActivada() {
        Debug.Log("Windmill Activated");
        rgb.AddTorque(100, 0, 0);
    }
}
