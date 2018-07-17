using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Plante))]
public class TailleModifier : MonoBehaviour {

    public GameObject gameObjectMesh;


    [SerializeField] private float taille = 1;
    [SerializeField] private float smooth = 3;


	// Use this for initialization
	void Start () {
        taille = gameObjectMesh.transform.localScale.y;

    }
	
	// Update is called once per frame
	void Update () {
        gameObjectMesh.transform.localScale = Vector3.Lerp(gameObjectMesh.transform.localScale, new Vector3(taille, taille, taille), Time.deltaTime * smooth);
        
    }


    public void modifySize(float newSize)
    {
        taille = newSize;
    }
}
