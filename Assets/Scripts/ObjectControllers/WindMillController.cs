using UnityEngine;
using System.Collections;

public class WindMillController : MonoBehaviour {

    ForgeController forge;
    PlankController plank;
    LogPileController logPile;
    public Transform log;
    Vector3 logPosition;


	// Use this for initialization
	void Start () {
	    forge = gameObject.transform.GetComponentInChildren<ForgeController>();
        plank = gameObject.transform.GetComponentInChildren<PlankController>();
        logPile = gameObject.transform.GetComponentInChildren<LogPileController>();
        logPosition = gameObject.transform.GetChild(2).position;
        logPosition.y += 1.8f;

    }
	
	// Update is called once per frame
	void Update () {
        if (forge.selected && plank.selected) {
            plank.ResetPlank();
            forge.Deselect();
            plank.Deselect();
        }

        if (forge.selected && logPile.selected) {
            forge.Deselect();
            logPile.Deselect();
            Instantiate(log, logPosition, Quaternion.identity);

        }
	}
}
