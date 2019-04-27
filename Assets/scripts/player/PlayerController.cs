using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent(typeof(PlayerCamera))]
[RequireComponent(typeof(PlayerInventaire))]
public class PlayerController : MonoBehaviour {

    public float ending = 0;
    public AudioClip Heal;

    // coefficient de la vitesse de la souris
    public float lookSensitivity = 1;

    // vitesse de déplacement du personnage
    public float movementSpeed = 1;

    // hauteur du saut
    public float jumpForce = 10;

    // le bon gros rigidbody
    [HideInInspector] public Rigidbody rig;
    private PlayerCamera playerCamera;
    private CharacterController playerController;
    private Animator anim;


    // variables approvisionnées durant l'Update, puis exploitées par FixedUpdate pour le déplacement du personnage
    private Vector3 moveRotation;
    private float cameraRotation;
    private Vector3 velocity;

    private bool isJumping = false;
    private float vertVelocity;

    public bool touch = false;



    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        playerCamera = GetComponent<PlayerCamera>();
        playerController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }
    
    void Start () {
        Utils.checkNull("Camera", playerCamera);

        // on lock la souris
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () {

        touch = playerController.isGrounded;

        // on récupère la souris en faisant echap (Debug only)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            isJumping = true;
        }

        rotation();

        calculVelocity();

    }


    private void FixedUpdate()
    {

        movement();
        playerCamera.rotationCamera(cameraRotation);

        // on rotate le joueur sur l'axe des X
        rig.MoveRotation(rig.rotation * Quaternion.Euler(moveRotation));

        applyGravity();
    }


    // rotation du personnage en fonction du déplacement de la souris
    private void rotation()
    {
        float _xRot = Input.GetAxisRaw("Mouse X") * lookSensitivity;
        float _yRot = Input.GetAxisRaw("Mouse Y") * lookSensitivity;

        // on récupère la valeur de la rotation à appliquer à la caméra pour l'axe des Y de la souris
        cameraRotation = _yRot;
        // on récupère la valeur de la rotation à appliquer au player en fonction du mouvement de l'axe X de la souris
        moveRotation = new Vector3(0, _xRot, 0);
    }


    // gestion du déplacement du personnage
    // modification de velocity, var ensuite utilisé par la fonction movement
    private void calculVelocity()
    {
        // on get les touches du clavier et/ou de la manette
        float _xMov = -Input.GetAxis("Horizontal") * movementSpeed;
        float _zMov = -Input.GetAxis("Vertical") * movementSpeed;

        Vector3 deplacement = new Vector3(_xMov, vertVelocity, _zMov);

        // on les converti en vecteurs de déplacement
        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _moveVertical = transform.forward * _zMov;

        velocity = transform.rotation * deplacement;
    }

    // modification de la position du personnage (physic)
    private void movement()
    {
        if(velocity != Vector3.zero)
        {
            //rig.MovePosition(rig.position + velocity * Time.fixedDeltaTime);
            playerController.Move(velocity * Time.fixedDeltaTime);
        }

    }

    private void applyGravity()
    {
        if (playerController.isGrounded)
        {
            if (!isJumping)
                vertVelocity = Physics.gravity.y;
            else
                vertVelocity = jumpForce;
        }
        else
        {
            vertVelocity += Physics.gravity.y * Time.fixedDeltaTime;
            vertVelocity = Mathf.Clamp(vertVelocity, -50f, jumpForce);
            isJumping = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Artefact"))
        {
            other.gameObject.SetActive(false);
            ending = ending + 1;
            GetComponent<AudioSource>().Play();
        }
        if (ending == 3)
        {
            SceneManager.LoadScene("End");
        }
    }
}
