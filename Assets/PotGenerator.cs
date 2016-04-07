using UnityEngine;
using System.Collections;

public class PotGenerator : MonoBehaviour {
    public Rigidbody pot;
    public float speed;
    public float repeatRate;

    // Use this for initialization
    void Start () {
        InvokeRepeating("LaunchPot",repeatRate,repeatRate);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void LaunchPot()
    {
        Rigidbody potClone = (Rigidbody)Instantiate(pot, transform.position, transform.rotation);
        potClone.velocity = transform.forward * speed;
    }
}
