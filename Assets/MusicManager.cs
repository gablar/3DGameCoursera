using UnityEngine;
using System.Collections;
using System;

public class MusicManager : MonoBehaviour {
    public AudioClip LoopOnClip;
    public AudioClip LoopOffClip;
    AudioSource source;
	// Use this for initialization
	void Start () {
	    source = GetComponent<AudioSource>();
        source.clip = LoopOffClip;
        source.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void EarthquakeEvent() {
        source.clip = LoopOffClip;
    }


    void OnEnable()
    {
        TerrainController.OnEarthquake += EarthquakeEvent;
        CloudController.OnRainStarted += RainStarted;
        CloudController.OnRainStopped += RainStopped;
    }


    void OnDisable()
    {
        TerrainController.OnEarthquake -= EarthquakeEvent;
        CloudController.OnRainStarted -= RainStarted;
        CloudController.OnRainStopped += RainStopped;
    }

    private void RainStopped()
    {
        source.clip = LoopOffClip;
        source.Play();
    }

    private void RainStarted()
    {
        source.clip = LoopOnClip;
        source.Play();
    }
}
