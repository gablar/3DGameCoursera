using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour {

    void Start() {
        
        //selection 
        rend = GetComponent<Renderer>();
        origColor = rend.material.color;
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

    void OnMouseDown() {
        if (selected)
        {
            rend.material.color = origColor;
            startcolor = origColor;
            selected = false;
        }
        else {
            rend.material.color = Color.blue;
            startcolor = Color.blue;
            selected = true;
        }
    }
}
