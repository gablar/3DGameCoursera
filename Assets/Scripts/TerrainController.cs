﻿using UnityEngine;
using System.Collections;

public class TerrainController : MonoBehaviour {
    public float eartquakeTime;
	private Animator anim;
	private AudioSource source;

	public delegate void Earthquake();
	public static event Earthquake OnEarthquake;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		source = GetComponent<AudioSource> ();
	}

	void OnEnable()
	{
		TerrainController.OnEarthquake += EarthquakeEvent;
	}


	void OnDisable()
	{
		TerrainController.OnEarthquake -= EarthquakeEvent;
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name.Equals ("TheCandle") && OnEarthquake != null ) {
			OnEarthquake ();
            Debug.Log("Candle trigger detected");
		}
	}

	void EarthquakeEvent() {
        if (source != null)
            source.Play();
        if (anim != null)
            anim.SetTrigger("earthquake");
       
        Invoke ("LlamarEarthquake", eartquakeTime);
	}

	void LlamarEarthquake() {
        EarthquakeEvent();
        if (OnEarthquake != null)
        {
            OnEarthquake();
            Debug.Log("Earthquake Triggered");
        }

    }
}
