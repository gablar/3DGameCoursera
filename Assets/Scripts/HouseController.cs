using UnityEngine;
using System.Collections;

public class HouseController : MonoBehaviour {

    FireWoodController firewood;
    OllaController olla;
	// Use this for initialization
	void Start () {
	    firewood = gameObject.transform.GetComponentInChildren<FireWoodController>();
        olla = gameObject.transform.GetComponentInChildren<OllaController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (firewood.selected && olla.selected) {
            olla.ResetOlla();
            firewood.Deselect();
            olla.Deselect();
        }
	}
}
