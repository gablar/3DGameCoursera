using UnityEngine;
using System.Collections;
using System;

public class BarrelStandController : MonoBehaviour {
    public SelectableObject barrel1Sel;
    public SelectableObject barrel2Sel;
    public BarrelController barrel1Controller;
    public BarrelController barrel2Controller;
    SelectableObject BarrelStandSel;
    public TerrainController Terrain;


 
    // Use this for initialization
    void Start () {
        BarrelStandSel = GetComponent<SelectableObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if (BarrelStandSel.selected && barrel1Sel.selected)
        {
            barrel1Sel.Deselect();
            barrel1Controller.ResetPosition();

        }
        if (BarrelStandSel.selected && barrel2Sel.selected)
        {
            barrel2Sel.Deselect();
            barrel2Controller.ResetPosition();
        }

        if (barrel1Controller.inPosition && barrel2Controller.inPosition) {
            Terrain.CancelInvoke();

        }

    }

}
