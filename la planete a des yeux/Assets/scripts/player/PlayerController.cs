using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent(typeof(PlayerCamera))]
public class PlayerController : MonoBehaviour {

    // coefficient de la vitesse de la souris
    public float lookSensitivity = 1;

    // vitesse de déplacement du personnage
    public float movementSpeed = 1;

    // le bon gros rigidbody
    [HideInInspector] public Rigidbody rig;
    private PlayerCamera playerCamera;


    // variables approvisionnées durant l'Update, puis exploitées par FixedUpdate pour le déplacement du personnage
    private Vector3 moveRotation;
    private float cameraRotation;
    private Vector3 velocity;



    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        playerCamera = GetComponent<PlayerCamera>();
    }
    
    void Start () {
        Utils.checkNull("Camera", playerCamera);

        // on lock la souris
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () {

        // on récupère la souris en faisant echap (Debug only)
        if (Input.GetKeyDown(KeyCode.Escape)){
		    if(Cursor.lockState != CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }

        /** Gestion de la rotation du personnage **/
        float _xRot = Input.GetAxisRaw("Mouse X");
        float _yRot = Input.GetAxisRaw("Mouse Y");

        // on récupère la valeur de la rotation à appliquer à la caméra pour l'axe des Y de la souris
        cameraRotation = _yRot;
        // on récupère la valeur de la rotation à appliquer au player en fonction du mouvement de l'axe X de la souris
        moveRotation = new Vector3(0, _xRot, 0);


        /** Gestion du déplacement du personnage **/

        // on get les touches du clavier et/ou de la manette
        float _xMov = -Input.GetAxis("Horizontal") * lookSensitivity;
        float _zMov = -Input.GetAxis("Vertical") * lookSensitivity;

        // on les converti en vecteurs de déplacement
        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _moveVertical = transform.forward * _zMov;

        velocity = (_moveHorizontal + _moveVertical) * movementSpeed;

    }

    private void FixedUpdate()
    {

        movement();
        playerCamera.rotationCamera(cameraRotation);

        // on rotate le joueur sur l'axe des X
        rig.MoveRotation(rig.rotation * Quaternion.Euler(moveRotation));
    }

    private void movement()
    {
        if(velocity != Vector3.zero)
        {
            rig.MovePosition(rig.position + velocity * Time.fixedDeltaTime);
        }
    }
}
