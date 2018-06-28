using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TailleModifier))]
[RequireComponent(typeof(CircleDetector))]
public class Massette : Plante {

    private CircleDetector detector;
    private TailleModifier tailleModifier;

    [Header("Gestion taille :")]
    public float tailleMinimum = 1;
    public float tailleMaximum = 2;

    private void Awake()
    {
        detector = GetComponent<CircleDetector>();
        tailleModifier = GetComponent<TailleModifier>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        GameObject detectedObj = detector.detected();

        if (detectedObj != null)
        {
            // gérer la detection ici
            if(detectedObj.tag == "Player")
            {
                Debug.Log("attaque!");
            }
        }
	}

    protected override void DoMoonAction(float fireMoonintensity, float coldMoonIntensity)
    {

    }

    protected override void DoubleMoonBegin()
    {

    }

    protected override void DoubleMoonEnd()
    {

    }
}
