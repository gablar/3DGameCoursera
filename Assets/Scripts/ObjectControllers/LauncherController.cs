using UnityEngine;
using System.Collections;

public class LauncherController : MonoBehaviour {
    public Rigidbody timber;
    public float speed;
    public float launchTime;


    public void Deactivate()
    {
        CancelInvoke();    
    }

    public void Activate()
    {
        InvokeRepeating("LaunchTimber", launchTime, launchTime);
    }

    void LaunchTimber() {
        Rigidbody timberClone = (Rigidbody)Instantiate(timber, transform.position, transform.rotation);
        timberClone.velocity = transform.forward * speed;
    }
}