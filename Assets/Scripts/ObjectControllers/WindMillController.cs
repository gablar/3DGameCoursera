using UnityEngine;
using System.Collections;

public class WindMillController : MonoBehaviour {

    ForgeController forge;
    PlankController plank;


	// Use this for initialization
	void Start () {
	    forge = gameObject.transform.GetComponentInChildren<ForgeController>();
        plank = gameObject.transform.GetComponentInChildren<PlankController>();

    }
	
	// Update is called once per frame
	void Update () {
        if (forge.selected && plank.selected) {
            plank.ResetPlank();
            forge.Deselect();
            plank.Deselect();
        }
	}
}
