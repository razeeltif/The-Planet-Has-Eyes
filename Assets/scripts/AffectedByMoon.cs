using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AffectedByMoon : MonoBehaviour {


    // on link l'event DoubleMoon à la fonction AffectedMoon::DoubleMoon
    protected void OnEnable()
    {
        MoonEvent.DoubleMoonBegin += DoubleMoonBegin;
        MoonEvent.DoubleMoonEnd += DoubleMoonEnd;
        MoonEvent.MoonPresence += DoMoonAction;
    }

    // on delink l'event DoubleMoon à la fonction AffectedMoon::DoubleMoon si l'objet est disabled
    protected void OnDisable()
    {
        MoonEvent.DoubleMoonBegin -= DoubleMoonBegin;
        MoonEvent.DoubleMoonEnd -= DoubleMoonEnd;
        MoonEvent.MoonPresence -= DoMoonAction;
    }

    /// <summary>
    /// action à réaliser lors de la présence d'au moins l'une des lunes
    /// </summary>
    /// <param name="fireMoonintensity"> intensité de la lune de feu apres calcul de coefficient (entre 0 et 1 )</param>
    /// <param name="coldMoonIntensity"> intensité de la lune de glace apres calcul de coefficient (entre 0 et 1) </param>
    protected abstract void DoMoonAction(float fireMoonintensity, float coldMoonIntensity);

    /// <summary>
    /// action à réaliser lors de l'apparition d'une double lune
    /// </summary>
    protected abstract void DoubleMoonBegin();

    /// <summary>
    /// action à réaliser lors de la fin d'une double lune
    /// </summary>
    protected abstract void DoubleMoonEnd();
    
}
