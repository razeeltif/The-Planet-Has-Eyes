using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;

    public MoonController fireMoon;
    public MoonController coldMoon;

    // intensité que doit atteindre la lune pour que celle-ci soit considéré à son zenith
    // DOIT ETRE TOUJOURS SUPERIEUR A MININTENSITY
    [Range(0, 1)] public float fireMoonZenith;
    [Range(0, 1)] public float coldMoonZenith;

    // intensité minimum de la lune pour avoir un impact sur l'environnement
    // DOIT ETRE TOUJOURS COMPRIS ENTRE 0 ET 1
    [Range(0, 1)] public float fireMoonMinIntensity;
    [Range(0, 1)] public float coldMoonMinIntensity;

    // timer du jeu
    [HideInInspector] public float timer;

    // indication si on est en double lune ou non
    public bool doubleMoon = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        if (fireMoonZenith < fireMoonMinIntensity)
        {
            Debug.LogError("fire Moon Zenith doit être supérieur à fire Moon Min Intensity");
        }

        if (coldMoonZenith < coldMoonMinIntensity)
        {
            Debug.LogError("cold Moon Zenith doit être supérieur à cold Moon Min Intensity");
        }
    }
	
	// Update is called once per frame
	void Update () {

        gestionMoonintensity();

    }

    private void gestionMoonintensity()
    {
        // on vérifie si au moins 1 des 2 lunes à un impact sur l'environnement
        if (fireMoon.moonIntensity > fireMoonMinIntensity || coldMoon.moonIntensity > coldMoonMinIntensity)
        {
            float _fireMoonIntensity = calculateMoonIntensity(fireMoon.moonIntensity, fireMoonMinIntensity);
            float coldMoonIntensity = calculateMoonIntensity(coldMoon.moonIntensity, coldMoonMinIntensity);

            // on notifie les éléments subissant l'impact des lunes
            MoonEvent.onMoonPresence(_fireMoonIntensity, coldMoonIntensity);
        }
        // si on est en double lune
        if (isDoubleMoon())
        {
            // check si c'est plus la double lune (si l'une des 2 lunes a une intensité au dessous de leur valeur de zenith
            if (fireMoon.moonIntensity < fireMoonZenith || coldMoon.moonIntensity < coldMoonMinIntensity)
            {
                MoonEvent.onDoubleMoonEnd();
                doubleMoon = false;
            }
        }
        // si on est pas en double lune
        else
        {
            // check si c'est la double lune (si les 2 lunes ont une intensité au dessus de leur valeur de zenith
            if (fireMoon.moonIntensity >= fireMoonZenith && coldMoon.moonIntensity >= coldMoonMinIntensity)
            {
                MoonEvent.onDoubleMoonBegin();
                doubleMoon = true;
            }
        }
    }

    // calcule le coefficient de l'intensité de la lune en fonction de fireMoonMinIntensity
    // retourne une valeur entre 0 et 1
    private float calculateMoonIntensity(float _MoonIntensity, float _MoonMinIntensity)
    {
        float _returnValue = 0;
        // dans le cas où les 1 des 2 lunes n'a pas d'impact, on passe son intensité à 0, la valeur minimum
        if ((_MoonIntensity - _MoonMinIntensity) < 0) return _returnValue;

        // calcul d'intensité de la lune
        _returnValue = (_MoonIntensity - _MoonMinIntensity) / (1 - _MoonMinIntensity);

        return _returnValue;
    }

    public bool isDoubleMoon() { return doubleMoon; }

    // get l'instance unique du GameManager
    public static GameManager getInstance()
    {
        return instance;
    }
}
