using UnityEngine;
using System.Collections;

public class TimberController : MonoBehaviour {
    public float selfDestructTime;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, selfDestructTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
