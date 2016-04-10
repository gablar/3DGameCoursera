using UnityEngine;
using System.Collections;
using System;

public class TreeController : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.speed = 0;
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnEnable()
    {
        CloudController.OnRainStarted += RainStarted;
        CloudController.OnRainStopped += RainStopped;


    }

    void OnDisable()
    {
        CloudController.OnRainStarted -= RainStarted;
        CloudController.OnRainStopped += RainStopped;


    }

    private void RainStopped()
    {
        anim.speed = 0;
    }

    private void RainStarted()
    {
        anim.speed = 1;
    }
}
