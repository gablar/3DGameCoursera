using UnityEngine;
using System.Collections;

public class WindBladeController : MonoBehaviour {
    Rigidbody rgb;
    public float maxRotSpeed;
    AudioSource windmillSound;

    public delegate void WindmillActivado();
    public static event WindmillActivado OnWindmillActivado;

    public delegate void WindmillDesactivado();
    public static event WindmillDesactivado OnWindmillDesactivado;


    // Use this for initialization
    void Start () {
        rgb = GetComponent<Rigidbody>();
        windmillSound = GetComponent<AudioSource>();
	}

    void Update() {

        if (rgb.angularVelocity.x >= maxRotSpeed)
        {
            if (OnWindmillActivado != null)
            {
                OnWindmillActivado();
            }
            if (!windmillSound.isPlaying)
            {
                windmillSound.Play();
            }
        }
        else {
            if (OnWindmillDesactivado != null)
            {
                OnWindmillDesactivado();
            }

            windmillSound.Stop();
        }
        
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
        //Debug.Log("Windmill Activated");
        rgb.AddTorque(100, 0, 0);
    }


}
