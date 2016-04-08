using UnityEngine;
using System.Collections;
using System;

public class CloudController : MonoBehaviour {
    public float delay;
    ParticleSystem ps;

    // Use this for initialization
    void Start () {
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
	}
	

    void OnEnable() {
        SteamController.OnSteamRedirigido += SteamRedirigido;
        SteamController.OnSteamNoRedirigido += SteamNoRedirigido;
    }

    void OnDisable() {
        SteamController.OnSteamRedirigido -= SteamRedirigido;
        SteamController.OnSteamNoRedirigido -= SteamNoRedirigido;

    }

    private void SteamNoRedirigido()
    {
        ps.Stop();
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void SteamRedirigido()
    {
        //Debug.Log("Steam Redirigido detectado");
        Invoke("StartCloud",delay);
        Invoke("StartRain",delay+2);
    }

    void StartCloud() {
        ps.Play();
    }

    void StartRain() {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);

    }
}