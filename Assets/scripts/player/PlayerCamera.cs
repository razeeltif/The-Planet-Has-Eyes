using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    // la camera du joueur
    [SerializeField] private Camera playerCamera;

    // angle possible de la mobilité de la caméra sur l'axe des Y
    [SerializeField] private float cameraAngleLimit;

    // variable servant à la gestion de l'axe des Y de la caméra, en particulier pour que l'angle de celle-ci ne depasse pas la valeur cameraLimit
    private float currentCameraRotation;


    // valeurs utiles pour le déplacement de la caméra suite à une détection de collision
    private Vector3 cameraDirection;
    private float distancePlayerCamera;

    // distance minimum entre le joueur et la caméra
    [SerializeField] private float minDistance = 0.5f;

    // distance maximum entre le joueur et la caméra
    [SerializeField] private float maxDistance = 4f;

    // coefficient jouant sur la douceur de déplacement de la caméra
    [SerializeField] private float smooth = 10.0f;


    private void Awake()
    {
        cameraDirection = playerCamera.transform.localPosition.normalized;
        distancePlayerCamera = playerCamera.transform.localPosition.magnitude;
    }

	
	// Update is called once per frame
	void Update () {

        gestionCollision();

    }

    public void rotationCamera(float _cameraRotation)
    {
        // gestion de l'angle maximum de la camera sur l'axe des Y
        if ((_cameraRotation < 0 && currentCameraRotation <= cameraAngleLimit) || (_cameraRotation > 0 && currentCameraRotation >= -cameraAngleLimit))
        {
            currentCameraRotation += _cameraRotation;

            // on clamp la cameraRotation pour qu'elle ne passe pas au dessus de la limite de la camera 
            if (currentCameraRotation > cameraAngleLimit)
            {
                _cameraRotation = _cameraRotation - (currentCameraRotation - cameraAngleLimit);
                currentCameraRotation = cameraAngleLimit;
            }

            // on clamp la cameraRotation pour qu'elle ne passe pas en dessous de la limite de la camera
            if (currentCameraRotation < -cameraAngleLimit)
            {
                _cameraRotation = _cameraRotation - (currentCameraRotation + cameraAngleLimit);
                currentCameraRotation = -cameraAngleLimit;
            }

            // on déplace la caméra autour du joueur en fonction dela souris
            playerCamera.transform.RotateAround(this.transform.position, transform.right, _cameraRotation);
        }
    }

    // pour éviter qu'un objet se trouve entre la caméra et le joueur, on déplace la camera devant ledit objet
    public void gestionCollision()
    {
        // position de la camera calculé à partir du joueur
        Vector3 desiredCameraPos = transform.TransformPoint(cameraDirection * maxDistance);

        RaycastHit hit;

        // lancé de ligne. si intersection => objet entre la camera et le joueur
        if (Physics.Linecast(transform.position, desiredCameraPos, out hit))
        {
            // on récupère la nouvelle distance entre le joueur et la camera
            distancePlayerCamera = Mathf.Clamp(hit.distance * 0.9f, minDistance, maxDistance);
        }
        else
        {
            // si pas d'objet détecté, on remet la distance max entre le joueur et la camera
            distancePlayerCamera = maxDistance;
        }
        // on modifie la position de la camera en lui appliquant la distance retournée.
        // on fait une interpolation linéaire de ce déplacement pour avoir un rendu plus doux
        playerCamera.transform.localPosition = Vector3.Lerp(playerCamera.transform.localPosition, cameraDirection * distancePlayerCamera, Time.deltaTime * smooth);
    }
}
