using UnityEngine;
using System.Collections;

public class ForgeController : MonoBehaviour {
    public delegate void ForgeActivada();
    public static event ForgeActivada OnForgeActivada;
    // Use this for initialization

	void Start () {
        rend = GetComponent<Renderer>();
        origColor = rend.material.color;
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Log") {
            //Debug.Log("Log collided with Forge");
            if (OnForgeActivada != null) {
                OnForgeActivada();
            }
        }
    }

    //selection

    Renderer rend;
    public bool selected;
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

    public void Deselect()
    {
        rend.material.color = origColor;
        startcolor = origColor;
        selected = false;
    }

    void Select()
    {
        rend.material.color = Color.blue;
        startcolor = Color.blue;
        selected = true;
    }
}
