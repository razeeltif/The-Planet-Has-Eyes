using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Plante))]
public class TailleModifier : MonoBehaviour {

    public MeshRenderer planteMesh;

    public float taille = 1;

    public float smooth = 3;


	// Use this for initialization
	void Start () {
        taille = planteMesh.transform.localScale.y;

    }
	
	// Update is called once per frame
	void Update () {
        planteMesh.transform.localScale = Vector3.Lerp(planteMesh.transform.localScale, new Vector3(taille, taille, taille), Time.deltaTime * smooth);
        
    }


    public void modifySize(float newSize)
    {
        taille = newSize;
    }
}
