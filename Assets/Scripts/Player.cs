using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //public vs private for variables
    //data type (int,float,bool,string)
    // int=integer values
    //float= numbers that include decimals
    //bool like ifs that are true or false
    //string=text
    //variable name declared after public/private declaration
    //4th optional part is value
    //private variable best practice: _<name>
    //best practice private unless variable needs to interact
    // [SerializeField] is an attribute that allows designers to adjust variables while keeping
    // other game objects from affecting those variables


    private float _speed = 10f;
    public float Horizontal;
    [SerializeField]
    private float _laserspeed = 1.3f;
    [SerializeField]
    private float _fireRate = .5f;
    private float _nextFire = .0f;
    [SerializeField]
    public int ShipLives = 4;
    [SerializeField]
    private float _nextspawn = 0.0f;
    [SerializeField]
    private float _spawntimer = 5.0f;
    float _laserposition;
    [SerializeField]
    private GameObject _Laserprefab;
    public GameObject _Enemyship;
    [SerializeField]
    private GameObject _TripleShot;
    [SerializeField]
    private GameObject _Player;
    private SpawnManager _spawnManager;
    [SerializeField]
    private bool _laserupgrade = false;


    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("The spawn manager is NULL!");
        }
           //modify start position to 0,0,0
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //move with wasd
        MovementInput();

        //instantiate laser capusle when player hits space key
        Laserfire();

        Laserupgrade();
        

        if (ShipLives <= 0)
        {
            Object.Destroy(this.gameObject);
            Time.timeScale = 0;
            Debug.Log("Game Over");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemies")
        {
            Damage();
        }
        else if (other.tag == "Attacks")
        {
            
            _laserupgrade = true;
        }
    }
    public void Damage()
    {
        ShipLives = ShipLives - 1;
        Debug.Log(this.ShipLives + "remaining");
        if (ShipLives <= 0)
        {
            Object.Destroy(this.gameObject);
            Time.timeScale = 0.0f;
            _spawnManager.OnPlayerDeath();
        }
    }
    void Laserfire()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire && _laserupgrade == true)
        { Instantiate(_TripleShot, transform.position + new Vector3(0, .5f, 0), Quaternion.identity);

        }
        else if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
                
                Instantiate(_Laserprefab, transform.position + new Vector3(0, .5f, 0), Quaternion.identity);
        }
    }

  private void Laserupgrade()
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Attacks")
            {
                Object.Destroy(other.gameObject);
                Debug.Log("Laser Upgrade acquired");
                _laserupgrade = true;

            }
        }
    }

public void MovementInput()
    {
    // transform.Translate(Vector3.right*_speed*Time.deltaTime);
    //transform.Translate(Vector3.up * _speed * Time.deltaTime);
    //the above two simply move the block each frame
    //vector3.right is standardized to (1,0,0)
    //vector3.up is standardized to (0,1,0)
    // transform.localScale = new Vector3(4, 4, 4);

    float HorizontalInput = Input.GetAxis("Horizontal");
    float VerticalInput = Input.GetAxis("Vertical");
    // the following code is how we're translating the object based on getaxis input which feeds back an actual value
    //for vertical and horizontal the input range is from -1 to 1
    // getaxis input meaning the button is pushed down for the respective axis (hot key mappings native to Unity)

    transform.Translate(Vector3.right * HorizontalInput * _speed * Time.deltaTime);
    transform.Translate(Vector3.up * VerticalInput * _speed * Time.deltaTime);

    //if transform.position on x, y is > bounds then set speed = 0

    if (transform.position.y >= 5)
    {
        transform.position = new Vector3(transform.position.x, 5, 0);
    }
    else if (transform.position.y <= -5)
    {
        transform.position = new Vector3(transform.position.x, -5, 0);
    }
    if (transform.position.x >= 10.7f)
    {
        transform.position = new Vector3(-10.7f, transform.position.y, 0);
    }
    else if (transform.position.x <= -10.7f)
    {
        transform.position = new Vector3(10.7f, transform.position.y, 0);
    }
}
}    
   
