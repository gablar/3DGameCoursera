using UnityEngine;
using System.Collections;

public class RainController : MonoBehaviour {
    AudioSource rainSound;
    // Use this for initialization

    void OnAwake() {
        rainSound = GetComponent<AudioSource>();
        rainSound.Stop();
    }

    void OnEnable() {
        rainSound.Play();
    }

    void OnDisable() {
        rainSound.Stop();
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
