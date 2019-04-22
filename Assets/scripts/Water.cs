using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : AffectedByMoon {

    // valeur de la plus haute hauteur de l'eau
    public float MaxHeight;

    private float waterHeight;

    public bool isSolid = false;

	// Use this for initialization
	void Start () {
        waterHeight = transform.position.y;

    }

    public float getWaterHeight(){ return waterHeight; }

    public void setWaterHeight(float _height)
    {
        waterHeight = _height;
        transform.position = new Vector3(transform.position.x, waterHeight, transform.position.z);
    }

    // 1) faire monter / baisser le niveau de l'eau en fonction de l'intensité de la lune de feu
    // 2) rendre solide l'eau lorsque la lune de glace atteind son zenith
    protected override void DoMoonAction(float fireMoonintensity, float coldMoonIntensity)
    {
        // modification de la hauteur de l'eau en fonction de l'intensité de la lune de feu
        setWaterHeight((1 - fireMoonintensity) * MaxHeight);
    }

    // rendre liquide l'eau
    protected override void DoubleMoonBegin()
    {
        Debug.Log("Debut Double lune !");
    }

    protected override void DoubleMoonEnd()
    {
        Debug.Log("Fin Double lune !");
    }
}
