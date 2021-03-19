using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavyship : MonoBehaviour
{
    [SerializeField]
    private GameObject _Player;
    [SerializeField]
    private GameObject _Heavyship;
    private float _speed = 4.5f;
    private int _ShipLives = 4;
    // Start is called before the first frame update
    void Start()
    {

        transform.position = new Vector3(Random.Range(-9.7f, 9.7f), 7, 0);

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
            _ShipLives = _ShipLives - 1;
            Debug.Log("Hit: " + this.transform.name);
        }
    }



    public void Damage()
    {
        _ShipLives = _ShipLives - 1;
        Debug.Log(this._ShipLives + "remaining");
        if (_ShipLives <= 0)
        {
            Object.Destroy(this.gameObject);
            Time.timeScale = 0;
        }


    }
}
