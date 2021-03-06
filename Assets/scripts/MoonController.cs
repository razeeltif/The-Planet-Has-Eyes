﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonController : MonoBehaviour {

    // la DirectionalLight correspondant à la lumière émise par la lune
    [SerializeField] private Light moon;

    // le temps que met la lune pour faire un cycle complet
    [SerializeField] private float secondsInFullDayMoon = 120f;

    // L'endroit où se trouve la lune au niveau de son cycle, avec 0 pour le tout début de levé, et 1 pour le couché
    // et donc la lune est  à son zenith à 0.5
    [Range(0, 1)] public float currentTimeMoon = 0f;

    // entre 0 et 1, correspond à l'impact de la lune sur l'environnement
    public float moonIntensity;

    private float timeMultiplier = 1f;
    private float moonInitialIntensity;

    // Use this for initialization
    void Start () {
        moonInitialIntensity = moon.intensity;
    }
	
	// Update is called once per frame
	void Update () {

        // modifier le current time
        currentTimeMoon += (Time.deltaTime / secondsInFullDayMoon) * timeMultiplier;

        // currentTimeMoon == 1 => fin d'un cycle, on retourne à 0
        if (currentTimeMoon >= 1)
        {
            currentTimeMoon = 0;
        }

        // modifier la position de la lune en fonction du current time
        // modifier l'intensité de la lumière en fonction du current time
        UpdateMoonPosition();

    }



    void UpdateMoonPosition()
    {
        // et on fait tourner les lumières !    (pardon)
        moon.transform.localRotation = Quaternion.Euler((currentTimeMoon * 360f) - 90, 170, 0);

        // modification de l'intensité de la lumière
        moonIntensity = Mathf.Sin(currentTimeMoon * Mathf.PI);

        // modification de l'intensité de la lumière émise par le lune
        moon.intensity = moonInitialIntensity * moonIntensity;
    }

    public float MoonIntensity
    {
        get { return moonIntensity; }
        set { moonIntensity = value; }
    }
}
