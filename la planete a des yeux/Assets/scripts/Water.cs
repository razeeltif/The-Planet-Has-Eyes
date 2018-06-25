using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    private float waterHeight;

    public bool isSolid = false;

	// Use this for initialization
	void Start () {
        waterHeight = transform.position.y;

    }
	
	// Update is called once per frame
	void Update () {
        /*GameManager.getInstance().fireMoon.moonIntensity;
        GameManager.getInstance().coldMoon.moonIntensity;*/


    }



    public float getWaterHeight(){ return waterHeight; }

    public void setWaterHeight(float _height)
    {
        waterHeight = _height;
        transform.position = new Vector3(transform.position.x, waterHeight, transform.position.z);
    }
}
