using UnityEngine;
using System.Collections;

public class LauncherController : MonoBehaviour {
    public Rigidbody timber;
    public float speed;
    public float launchTime;
    public bool activate = false;
    bool isActivated = false;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!isActivated && activate)
        {
            InvokeRepeating("LaunchTimber", launchTime, launchTime);
            isActivated = true;
        }
        else if (isActivated && !activate) {
            CancelInvoke();
            isActivated = false;
        }
    }

    void LaunchTimber() {
        Rigidbody timberClone = (Rigidbody)Instantiate(timber, transform.position, transform.rotation);
        timberClone.velocity = transform.forward * speed;
    }
}