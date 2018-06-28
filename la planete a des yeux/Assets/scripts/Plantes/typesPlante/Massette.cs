using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TailleModifier))]
[RequireComponent(typeof(CircleDetector))]
public class Massette : Plante {

    [Header("Animation Attaque")]
    public Animator attackanimator;

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
        attackanimator = this.transform.GetChild(0).GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        
        GameObject detectedObj = detector.detected();

        if (detectedObj != null)
        {
            // gérer la detection ici
            if(detectedObj.tag == "Player")
            {
                this.gameObject.transform.LookAt(detectedObj.transform.position, Vector3.up);
                attackanimator.Play("attack");
                Debug.Log(this.gameObject.name);
            }
        }
	}

    protected override void DoMoonAction(float fireMoonintensity, float coldMoonIntensity)
    {
        //throw new System.NotImplementedException();
    }

    protected override void DoubleMoonBegin()
    {
        //throw new System.NotImplementedException();
    }

    protected override void DoubleMoonEnd()
    {
        //throw new System.NotImplementedException();
    }
}
