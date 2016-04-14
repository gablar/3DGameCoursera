using UnityEngine;
using System.Collections;
using System;

public class SteamController : MonoBehaviour {
    private bool steamActivado = false;
    bool ollaEnPosicion = true;
    ParticleSystem particles;

    //events

    public delegate void SteamRedirigido();
    public static event SteamRedirigido OnSteamRedirigido;

    public delegate void SteamNoRedirigido();
    public static event SteamNoRedirigido OnSteamNoRedirigido;


    // Use this for initialization
    void Start () {
        particles = GetComponent<ParticleSystem>();
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
            if (OnSteamNoRedirigido != null)
            {
                OnSteamNoRedirigido();
            }
        }
    }

    public void WindmillActivado() {
        //Debug.Log("Steam detected windmill activation");
        if (!steamActivado )
        {
            gameObject.transform.Rotate(90,0,0);
            steamActivado = true;
            if (OnSteamRedirigido != null && ollaEnPosicion)
            {
                OnSteamRedirigido();
            }
        }
    }

    private void OllaActivada()
    {
        particles.Play();
        ollaEnPosicion = true;
    }

    private void OllaDesactivado()
    {
        particles.Stop();
        ollaEnPosicion = false;
    }

   

}
