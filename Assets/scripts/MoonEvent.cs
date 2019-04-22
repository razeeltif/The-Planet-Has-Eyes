using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// note : tous ces events sont appelé dans le Gamemanager
public class MoonEvent {

    // event appelé pour annoncer le début de la cdouble lune
    public delegate void DoubleMoonBeginEvent();
    public static event DoubleMoonBeginEvent DoubleMoonBegin;

    // event appelé pour annoncer la fin de la double lune
    public delegate void DoubleMoonEndEvent();
    public static event DoubleMoonEndEvent DoubleMoonEnd;

    // event appelé pour indiquer aux éléments subissant l'impact des doubles lunes leurs intensité respectives
    // est appelé à chaque Update dès lors qu'une lune a une intensité assez élevé pour avoir un impact (void GameManager.xxxxMoonMinIntensity pour connaitre le seuil d'intensité que doit avoir une lune pour avoir un impact) 
    public delegate void MoonPresenceEvent(float fireMoonIntensity, float coldMoonIntensity);
    public static event MoonPresenceEvent MoonPresence;


    public static void onDoubleMoonBegin()
    {
        DoubleMoonBegin();
    }

    public static void onDoubleMoonEnd()
    {
        DoubleMoonEnd();
    }

    public static void onMoonPresence(float fireMoonIntensity, float coldMoonIntensity)
    {
        MoonPresence(fireMoonIntensity, coldMoonIntensity);
    }



}
