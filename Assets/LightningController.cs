using UnityEngine;
using System.Collections;

public class LightningController : MonoBehaviour {

    AudioSource thunderSound;
    ParticleSystem thunderParticle;
    // Use this for initialization

    void Awake()
    {
        thunderSound = GetComponent<AudioSource>();
        thunderSound.Stop();
        thunderParticle = GetComponent<ParticleSystem>();
        thunderParticle.Stop();
    }


    public void PlayThunder() {
        thunderSound.Play();
        thunderParticle.Play();
    }

}
