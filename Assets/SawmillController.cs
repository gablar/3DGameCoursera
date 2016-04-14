using UnityEngine;
using System.Collections;
using System;

public class SawmillController : MonoBehaviour {

    // Use this for initialization
    public float treeTimer;
    float t =0;
    LauncherController launcher;
    MillController mill;
    void Start () {
        launcher = gameObject.transform.GetComponentInChildren<LauncherController>();
        mill = gameObject.transform.GetComponentInChildren<MillController>();
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if (t > treeTimer) {
            launcher.activate = false;
            t = 0;
        }
	}

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Tree")) {
            Destroy(other.gameObject, 1);
        }

        launcher.activate = true;
        t = 0;
    }

    void OnEnable()
    {
        TerrainController.OnEarthquake += EarthquakeEvent;
    }


    void OnDisable()
    {
        TerrainController.OnEarthquake -= EarthquakeEvent;
    }

    private void EarthquakeEvent()
    {

        mill.EarthquakeEvent();
        launcher.activate = false;

    }


}