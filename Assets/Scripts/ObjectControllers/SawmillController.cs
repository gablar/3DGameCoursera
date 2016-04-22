using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class SawmillController : MonoBehaviour {

    // Use this for initialization
    public float treeTimer;
    float t = 0;
    LauncherController launcher;
    MillController mill;
    Transform leaves;
    Transform wood;

    void Start() {
        launcher = gameObject.transform.GetComponentInChildren<LauncherController>();
        mill = gameObject.transform.GetComponentInChildren<MillController>();


        //particle system
        leaves = gameObject.transform.GetChild(2);
        wood = gameObject.transform.GetChild(3);
        leaves.gameObject.SetActive(false);
        wood.gameObject.SetActive(false);

        rend = GetComponent<Renderer>();
        origColor = rend.material.color;
    }

    // Update is called once per frame
    void Update() {
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

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Tree"))
        {
            if (mill.resetBlade)
            {
                Destroy(other.gameObject);
                launcher.Activate();
                mill.ActivateMill();
                ActivateParticles();
                Invoke("DeactivateParticles", 5);
                t = 0;
                //ANALYTICS
                Analytics.CustomEvent("Sawmill", new Dictionary<string, object>
                              {
                                { "SawStarted", Time.realtimeSinceStartup }
                              });

            }

        
        }


    }

    private void ActivateParticles()
    {
        wood.gameObject.SetActive(true);
        leaves.gameObject.SetActive(true);
    }

    private void DeactivateParticles() {
        wood.gameObject.SetActive(false);
        leaves.gameObject.SetActive(false);
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