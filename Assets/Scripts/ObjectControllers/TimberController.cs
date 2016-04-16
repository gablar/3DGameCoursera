using UnityEngine;
using System.Collections;

public class TimberController : MonoBehaviour {
    public float selfDestructTime;
    AudioSource thud;
	// Use this for initialization
	void Start () {
        thud = GetComponent<AudioSource>();
        Destroy(gameObject, selfDestructTime);
	}

    // Update is called once per frame
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Forge")
        {
            
            transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject,0.5f);
        }
        thud.Play();
    }
}