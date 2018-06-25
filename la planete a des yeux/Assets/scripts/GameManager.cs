using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;

    public MoonController fireMoon;
    public MoonController coldMoon;

    public float fireMoonZenith;
    public float coldMoonZenith;

    public float fireMoonMinIntensity;
    public float coldMoonMinIntensity;

    public float timer;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // get l'instance unique du GameManager
    public static GameManager getInstance()
    {
        return instance;
    }
}
