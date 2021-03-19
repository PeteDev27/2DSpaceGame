using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyship : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject _Enemyship;
    [SerializeField]
    private bool _ispresent = false;
    [SerializeField]
    private float _speed = 3.2f;
    [SerializeField]
    private GameObject _Player;
    private float _spawntimer = 5.0f;
    [SerializeField]
    private float _nextspawn = 5.0f;
    public GameObject activeInHiearchy;
    public int ShipLives = 4;
    public void Damage()
    {
    
    }
    // private int _Enemyshipsmax = 6;
    void Start()
    {
        transform.position = new Vector3(Random.Range(-9.7f, 9.7f), 7, 0);
        //if (_nextspawn == 0.0f)
       // {
        //    _nextspawn = _spawntimer + Time.time;
        //    Debug.Log(_nextspawn + "till ship arrives");
        //    Instantiate(this.gameObject, new Vector3(Random.Range(-9.7f, 9.7f), 7.5f, 0.0f), Quaternion.identity);
       // }
        //  if(_ispresent = true)
        // {
        //  Object.Destroy(_Enemyship);
        // }
        // Instantiate(this.gameObject, new Vector3(5,Random.value,0), Quaternion.identity);
        //  transform.SetPositionAndRotation(new Vector3(2, 2, 0), Quaternion.identity);
        // _ispresent = true;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -5.4f)
        {
            transform.position = new Vector3(Random.Range(-9.7f, 9.7f), 7.5f, 0.0f);
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = new Vector3(0, -3.2f, 0);
            ShipLives = ShipLives - 1;
            Debug.Log("Hit: " + this.transform.name);
        }
    }
}





// if (_ispresent = false)
// {
//     Instantiate(_Enemyship, transform.position + new Vector3(3.1f, 10.3f, 0), Quaternion.identity);
//     transform.SetPositionAndRotation(new Vector3(2, 2, 0), Quaternion.identity);
//     _ispresent = true;
// }
//if (_ispresent = true)
//{
  //  Debug.Log("Enemy Ship!");
   // Object.Destroy(this.gameObject);
//}