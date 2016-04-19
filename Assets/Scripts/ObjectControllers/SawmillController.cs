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

        rend = GetComponent<Renderer>();
        origColor = rend.material.color;
    }
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if (t > treeTimer) {
            mill.DeactivateMill();
            launcher.Deactivate();

            t = 0;
        }

        if (selected && mill.selected) {
            mill.ResetBlade();
            Deselect();
            mill.Deselect();
        }
	}

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Tree")) {
            Destroy(other.gameObject, 1);
            launcher.Activate();
            mill.ActivateMill();

            t = 0;
        }


    }

    private void EarthquakeEvent()
    {

        launcher.Deactivate();

    }

    void OnEnable()
    {
        TerrainController.OnEarthquake += EarthquakeEvent;
    }


    void OnDisable()
    {
        TerrainController.OnEarthquake -= EarthquakeEvent;
    }


    //selection

    Renderer rend;
    bool selected;
    private Color startcolor;
    private Color origColor;
    void OnMouseEnter()
    {
        startcolor = rend.material.color;
        rend.material.color = Color.yellow;
    }
    void OnMouseExit()
    {
        rend.material.color = startcolor;
    }

    void OnMouseDown()
    {
        if (selected)
        {
            Deselect();
        }
        else {
            Select();
        }
    }

    void Deselect() {
        rend.material.color = origColor;
        startcolor = origColor;
        selected = false;
    }

    void Select() {
        rend.material.color = Color.blue;
        startcolor = Color.blue;
        selected = true;
    }
}