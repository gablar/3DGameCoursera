using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class CloudController : MonoBehaviour {
    public float delay;
    ParticleSystem ps;
    LightningController thunder;
    Animator treeAnim;
    AudioSource thunderSound;
    bool isRedirected  = false;
    private bool cloudComplexStarted;


    //delegates

    public delegate void RainStarted();
    public static event RainStarted OnRainStarted;

    public delegate void RainStopped();
    public static event RainStopped OnRainStopped;

    // Use this for initialization
    void Start () {
        ps = GetComponent<ParticleSystem>();
        ps.Stop();

        thunder = gameObject.transform.GetChild(1).GetComponent<LightningController>();
	}

    void Update() {
        
    }

    void OnEnable() {
        SteamController.OnSteamRedirigido += SteamRedirigido;
        SteamController.OnSteamNoRedirigido += SteamNoRedirigido;
        TreeController.OnTreeGrown += TreeGrown;
    }

    void OnDisable() {
        SteamController.OnSteamRedirigido -= SteamRedirigido;
        SteamController.OnSteamNoRedirigido -= SteamNoRedirigido;
        TreeController.OnTreeGrown -= TreeGrown;


    }

    private void SteamNoRedirigido()
    {
        isRedirected = false;
        StopCloudSystem(); 
    }

    private void SteamRedirigido()
    {
        isRedirected = true;
        //Debug.Log("Steam Redirigido detectado");
        cloudComplexStarted = true;
        Invoke("StartCloud",delay);
        Invoke("StartRain",delay+2);
    }

    void TreeGrown() {
        thunder.PlayThunder();
    }

    void StartCloud() {
        if (isRedirected)
            ps.Play(false);
    }

    void StartRain() {
        if (isRedirected)
        {
            Analytics.CustomEvent("rainStarted", new Dictionary<string, object>
                              {
                                { "rainStarted", Time.realtimeSinceStartup }
                              });
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            if (OnRainStarted != null)
            {
                OnRainStarted();
            }
        }

    }

    void StopCloudSystem() {
        ps.Stop(false);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        CancelInvoke();

        if (OnRainStopped != null)
        {
            OnRainStopped();
        }
    }
}