using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class GameAnalytics : MonoBehaviour {
    // Use this for initialization
    bool start;
	void Start () {
        start = true;
       Analytics.CustomEvent("gameStarted", new Dictionary<string, object>
                              {
                                { "GameStarted", start }
                              });
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
