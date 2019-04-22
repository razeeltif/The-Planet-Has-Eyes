using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventaire : MonoBehaviour {

    private List<ObjetPortable> inventaire;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addObject(ObjetPortable obj)
    {
        inventaire.Add(obj);
    }

    public void removeObject(ObjetPortable obj)
    {
        inventaire.Remove(obj);
    }
}
