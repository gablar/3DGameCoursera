using UnityEngine;
using System.Collections;

public class TreeGeneratorController : MonoBehaviour {
    public Rigidbody tree;
    public bool spawnTree = true;
    bool raining;

    // Use this for initialization
    void Start () {
        SpawnTree();
	}

    void OnEnable()
    {
        CloudController.OnRainStarted += RainStarted;
        CloudController.OnRainStopped += RainStopped;
        TreeController.OnTreeGrown += TreeGrown;


    }

    void OnDisable()
    {
        CloudController.OnRainStarted -= RainStarted;
        CloudController.OnRainStopped += RainStopped;
        TreeController.OnTreeGrown -= TreeGrown;



    }

    // Update is called once per frame
    void Update () {
    }

    private void RainStopped()
    {
        raining = false;
    }

    private void RainStarted()
    {
        raining = true;
    }

    private void TreeGrown() {
        Invoke("SpawnTree",.3f);
    }

    void SpawnTree() {
        Rigidbody treeClone = (Rigidbody)Instantiate(tree, transform.position, transform.rotation);
        spawnTree = false;
        treeClone.GetComponent<TreeController>().raining = raining;
    }
}
