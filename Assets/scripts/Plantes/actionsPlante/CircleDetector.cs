using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDetector : MonoBehaviour {

    public float detectionRadius = 5f;
    [SerializeField] GameObject[] objetADetecter;

    // Use this for initialization
    void Start () {
        if (objetADetecter == null || objetADetecter.Length == 0)
            Debug.Log("La liste de détection de l'objet " + transform.name + " est vide");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    public GameObject detected()
    {

        GameObject res = null;

        foreach (GameObject obj in objetADetecter)
        {
            
            // get the direction vector3 between the detector and the detected
            Vector3 heading = obj.transform.position - transform.position;
            float distance = heading.magnitude;
            Vector3 direction = heading / distance;

            //we cast a ray if within the distance of sight
            if (distance <= detectionRadius)
            {
                RaycastHit hit;
                bool returnRaycast = false;
                returnRaycast = Physics.Raycast(transform.position, direction, out hit, detectionRadius);
                Debug.DrawRay(transform.position, direction * detectionRadius, Color.yellow, 0.5f);

                //test if the collided object with the raycast is the gameObject we are looking for
                if (returnRaycast)
                {
                    if (hit.collider.gameObject == obj)
                    {
                        return obj;
                    }
                }
            }
        }

        return res;
    }
}
