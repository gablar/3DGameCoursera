using UnityEngine;
using System.Collections;
using System;

public class SteamController : MonoBehaviour {
    private bool steamActivado = false;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        WindBladeController.OnWindmillActivado += WindmillActivado;
        WindBladeController.OnWindmillDesactivado += WindmillDesactivado;

    }

    void OnDisable()
    {
        WindBladeController.OnWindmillActivado -= WindmillActivado;
        WindBladeController.OnWindmillDesactivado -= WindmillDesactivado;

    }

    private void WindmillDesactivado()
    {
        if (steamActivado) {
            gameObject.transform.Rotate(-90, 0, 0);
            steamActivado = false;
        }
    }

    public void WindmillActivado() {
        //Debug.Log("Steam detected windmill activation");
        if (!steamActivado)
        {
            gameObject.transform.Rotate(90,0,0);
            steamActivado = true;
        }
    }


}
