using UnityEngine;
using System.Collections;

public class OllaController : MonoBehaviour {
    public bool ollaEnPosicion = true;
    public bool OcurrioTerremoto = false;
    public bool resetPosition;
    public float force;


    Vector3 posicionOlla;
    Quaternion rotacionOlla;
    Rigidbody rgb;
    
   



    //events

    public delegate void OllaActivada();
    public static event OllaActivada OnOllaActivada;

    public delegate void OllaDesactivado();
    public static event OllaDesactivado OnOllaDesactivado;

    // Use this for initialization
    void Start () {
        posicionOlla = transform.position;
        rotacionOlla = transform.rotation;
        rgb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update ()
    {   
        if (OcurrioTerremoto) {

            rgb.constraints = RigidbodyConstraints.None;
            rgb.AddForce(-transform.right*force);
            OcurrioTerremoto = false;
            ollaEnPosicion = false;
        }

        if (resetPosition) {
            transform.position = posicionOlla;
            transform.rotation = rotacionOlla;
            rgb.constraints = RigidbodyConstraints.FreezeAll;
            ollaEnPosicion = true;
        }
        EventoOllaEnPosicion();


    }


    private void EventoOllaEnPosicion()
    {
        if (ollaEnPosicion)
        {
            if (OnOllaActivada != null)
            {
                OnOllaActivada();
            }
        }
        else {
            if (OnOllaDesactivado != null)
            {
                OnOllaDesactivado();
            }
        }
    }
}
