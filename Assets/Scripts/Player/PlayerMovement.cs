using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rollSpeed;
    float startSpeed;
    public float groundDrag;

    [Header("Grounde Check")]
    [SerializeField] private float _playerHeight;
    [SerializeField] private bool _grounded;
    public LayerMask ground;


    public Transform orientation;

    private float _horizontalInput, _verticalInput;
    private Vector3 pointToLook, lookAt;


    Rigidbody myRb;
    Camera _mainCamera;

    private Animator _myAnim;
    [SerializeField] private string _xAxisName;
    [SerializeField] private string _zAxisName;
    [SerializeField] private AnimationClip _shootAnimation;

    public GunController gun;

    

    public HealthManager pHM;
    bool val = true;
    bool isRolling = false;
    bool isReloading = false;

    public float rollCounter;
    [SerializeField] private float _rollDelay;


    /*[SerializeField] private int _currentAmmo;
    [SerializeField] private int _maxAmmo;
    private float _shotDelay;*/

    public Pausa pause;
    [SerializeField] private bool _gameIsPaused;

    [SerializeField] GameObject _key;
    public GameObject Key { get { return _key; } }



    private PlayerAnimation _playerAnim;
    private PlayerSFX _playerSFX;

    public Vector3 getLookAt()
    {
        return lookAt;
    }

    public float getRollDelay()
    {
        return _rollDelay;
    }
    
    public float getRollCounter()
    {
        return rollCounter;
    }

    /*public void BuffGun(float val, float timer)
    {
        gun.BuffWeapon(val, timer);
    }*/

    private void Start()
    {
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSFX = GetComponent<PlayerSFX>();
        myRb = GetComponent<Rigidbody>();
        myRb.freezeRotation = true;
        _mainCamera = FindObjectOfType<Camera>();
        startSpeed = _moveSpeed;
        pHM = GetComponent<HealthManager>();
        //_maxAmmo = gun.getMaxAmmo();
        //_currentAmmo = _maxAmmo;
        //_shotDelay = gun.GetShotDelay();
    }

    private void Update()
    {
        var check = gun.fov.FieldOfViewCheck();
        val = pHM.getDmg();


        _grounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.5f + 0.2f, ground);
        if (_grounded)
            myRb.drag = groundDrag;
        else
            myRb.drag = 0;

        if (check)
        {
            check.Reveal();
        }

        if (!_gameIsPaused) 
        { 

            if (!isRolling)
                LookAround();

            if (!isReloading)
                Shoot();

            if (!gun.getIsFiring())
                Roll();

            MyInput();
            SpeedControl();
            OpenDoor();
        }

        _gameIsPaused = pause.getPausa();
        


    }

    private void OnTriggerEnter(Collider other)
    {
        /*if(other.tag == "Ammo")
        {
            var ammoBox = other.GetComponentInParent<Reload>();
            ammoBox.ActiveUI();

            isReloading = true;

        }*/
        if(other.tag == "Key")
        {
            _key = other.gameObject;
            other.gameObject.SetActive(false);
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Ammo")
        {

            var ammoBox = other.GetComponentInParent<Reload>();
            if (ammoBox.GetFill() >= 1)
            {
                gun.setAmmo(_maxAmmo);
                OnReload();
                isReloading = false;
                ammoBox.DeactiveUI();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ammo")
        {
            other.GetComponentInParent<Reload>().DeactiveUI();
            isReloading = false;
        }

    }*/



    private void FixedUpdate()
    {
        if (!gun.getIsFiring())
        {
            MovePlayer();
            _playerAnim.MoveAnimation(_horizontalInput, _verticalInput);
        }

        if (isRolling == true)
            myRb.AddForce(transform.forward * _rollSpeed, ForceMode.Impulse);

    }

    private void MyInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void OpenDoor()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 3))
            {
                var door = hit.collider.GetComponent<Doors>();

                if (door) {
                    if (!door.locked)
                    {
                        Debug.Log("abrido");
                        door.OpenDoor();
                    }
                    else if (_key)
                    {
                        door.UnlockDoor();
                    }
                    else
                    {
                        Debug.LogError("needs key");
                    }
                }
            }
        }
    }

    private void MovePlayer()
    {
        Vector3 moveInput = new Vector3(_horizontalInput, 0f, _verticalInput).normalized;

        myRb.AddForce(moveInput * _moveSpeed * 10f, ForceMode.Force);
    }

    private void LookAround()
    {
        Ray cameraRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, gun.transform.position);
        float raylenght;

        if (groundPlane.Raycast(cameraRay, out raylenght))
        {
            pointToLook = cameraRay.GetPoint(raylenght);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            lookAt = new Vector3(pointToLook.x, transform.position.y, pointToLook.z);

            transform.LookAt(lookAt);
            //Debug.DrawLine(this.transform.position, lookAt, Color.red);
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && gun.getAmmo() > 0 && !gun.getIsFiring())
        {
            gun.setIsFiring(true);
            StartCoroutine(crOnShoot()); 
            gun.setAmmo(gun.getAmmo() - 1);
        }
        else if (Input.GetMouseButtonDown(0) && gun.getAmmo() <= 0)
        {
            _playerSFX.OnNoAmmo();
        }

       if (Input.GetMouseButtonUp(0))
        {
            gun.setIsFiring(false);
        }
    }

    private void Roll()
    {
        rollCounter -= Time.deltaTime;
        if (rollCounter <= 0 && Input.GetMouseButtonDown(1))

        {
            rollCounter = _rollDelay;
            StartCoroutine(crOnRoll());
        }
        else
        {
            rollCounter -= Time.deltaTime;
        }
    }


    private void SpeedControl()
    {

        Vector3 flatVel = new Vector3(myRb.velocity.x, 0f, myRb.velocity.z);

        if (flatVel.magnitude > _moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * _moveSpeed;
            myRb.velocity = new Vector3(limitedVel.x, myRb.velocity.y, limitedVel.z);
        }

    }

    private IEnumerator crOnShoot()
    {
        _moveSpeed = 0;
        _playerAnim.Trigger("onShoot");
        _playerSFX.OnShoot(_gameIsPaused);
        yield return new WaitForSeconds(0.25f);
        _playerAnim.Trigger("onEndShoot");
        _moveSpeed = startSpeed;
    }

    private IEnumerator crOnRoll()
    {
        _moveSpeed = 0;
        _playerAnim.Trigger("onRoll");
        isRolling = true;
        pHM.setDmg(val);
        yield return new WaitForSeconds(.8f);
        _playerAnim.Trigger("onEndRoll");
        isRolling = false;
        pHM.setDmg(val);
        _moveSpeed = startSpeed;
    }
}


