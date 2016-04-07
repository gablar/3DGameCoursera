using UnityEngine;
using System.Collections;
using System;

public class SteamController : MonoBehaviour {
    private bool steamActivado = false;
    ParticleSystem particles;


    // Use this for initialization
    void Start () {
        particles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        WindBladeController.OnWindmillActivado += WindmillActivado;
        WindBladeController.OnWindmillDesactivado += WindmillDesactivado;
        OllaController.OnOllaActivada += OllaActivada;
        OllaController.OnOllaDesactivado += OllaDesactivado;

    }

    

    void OnDisable()
    {
        WindBladeController.OnWindmillActivado -= WindmillActivado;
        WindBladeController.OnWindmillDesactivado -= WindmillDesactivado;
        OllaController.OnOllaActivada -= OllaActivada;
        OllaController.OnOllaDesactivado -= OllaDesactivado;

    }

    private void WindmillDesactivado()
    {
        if (steamActivado) {
            gameObject.transform.Rotate(-90, 0, 0);
            steamActivado = false;
        }
    }

    public void WindmillActivado() {
        //Debug.Log("Steam detected windmill activation");
        if (!steamActivado)
        {
            gameObject.transform.Rotate(90,0,0);
            steamActivado = true;
        }
    }

    private void OllaActivada()
    {
        particles.Play();
    }

    private void OllaDesactivado()
    {
        particles.Stop();
    }

   

}
