using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TailleModifier))]
public class Kokonut_tree : Plante {

    private TailleModifier tailleModifier;

    [SerializeField] private float tailleMinimum = 0.5f;
    [SerializeField] private float tailleMaximum = 3f;

    [SerializeField] private float tailleMoyenne = 1.5f;


    // Use this for initialization
    void Awake()
    {
        tailleModifier = GetComponent<TailleModifier>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    protected override void DoMoonAction(float fireMoonintensity, float coldMoonIntensity)
    {
        float newTaille = 0;

        float moonsInfluence = fireMoonintensity - coldMoonIntensity;
        if (moonsInfluence < 0) moonsInfluence = 0;

        newTaille = ((tailleMaximum - tailleMinimum) * moonsInfluence) + tailleMinimum;

        tailleModifier.modifySize(newTaille);

    }

    protected override void DoubleMoonBegin()
    {


    }

    protected override void DoubleMoonEnd()
    {

    }


}
