﻿using UnityEngine;
using System.Collections;
using System;

public class TreeController : MonoBehaviour
{
     
    public bool raining;
    bool broken = false;
    public float destroyTime;


    public float speed;
    public Vector3 direction;


    Rigidbody rgb;
    Animator anim;

    //DELEGATES
    public delegate void TreeGrown();
    public static event TreeGrown OnTreeGrown;

    // Use this for initialization
    void Start()
    {
        
        anim = GetComponent<Animator>();
        
        rgb = GetComponent<Rigidbody>();


       
        if (raining)
        {
            RainStarted();
        }
        else {
            RainStopped();
        }
        
    }

    // Update is called once per frame
    void Update()
    {   

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("GrownTree") && !broken)
        {
            if (OnTreeGrown != null) {
                OnTreeGrown();
            }
            
            broken = true;
            Invoke("LaunchTree", 0.1f);
            Destroy(gameObject, destroyTime);
        }
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
        if(anim != null){
            anim.speed = 0;

        }
    }

    private void RainStarted()
    {
        anim.speed = 1;
    }

    void LaunchTree() {
        rgb.AddForce(direction * speed);
    }
    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Collision Name:" + other.transform.name);
        /*if (other.gameObject.tag == "Cart")
        {
            Debug.Log("Collision Tag: Cart ");
            gameObject.transform.SetParent(other.transform);

        }*/
    }
}
