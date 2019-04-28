using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour {

    public GameObject Texte;

    void Start()
    {
        StartCoroutine(RemoveAfterSeconds(6, Texte));
    }
    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(6);
        obj.SetActive(false);
    }

}
