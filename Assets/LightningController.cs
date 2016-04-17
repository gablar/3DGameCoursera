using UnityEngine;
using System.Collections;

public class LightningController : MonoBehaviour {

    AudioSource thunderSound;
    ParticleSystem thunderParticle;
    // Use this for initialization

    void OnAwake()
    {
        thunderSound = GetComponent<AudioSource>();
        thunderSound.Stop();
        thunderParticle = GetComponent<ParticleSystem>();
        thunderParticle.Stop();
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        thunderSound.Play();
        thunderParticle.Play();

    }

    void OnDisable()
    {
        thunderSound.Stop();
    }

}
