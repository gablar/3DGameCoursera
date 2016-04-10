using UnityEngine;
using System.Collections;
using System;

public class TreeController : MonoBehaviour
{
    public ParticleSystem thunder;
    Rigidbody rgb;
    Animator anim;


    public bool broken;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        
        rgb = GetComponent<Rigidbody>();
        anim.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("GrownTree") && broken)
        {
            thunder.Play();
            rgb.AddTorque(-transform.forward * 30);
            broken = false;
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
        anim.speed = 0;
    }

    private void RainStarted()
    {
        anim.speed = 1;
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
