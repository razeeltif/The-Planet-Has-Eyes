using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plante : AffectedByMoon {

    public bool movable;
    public float speed;
    [Header("Moons :")]
    [Range(0, 1)]
    public float iceMoonThreshold;
    [Range(0, 1)]
    public float fireMoonThreshold;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
