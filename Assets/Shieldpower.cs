using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shieldpower : MonoBehaviour
{
    [SerializeField]
    private GameObject _Shieldpower;
    [SerializeField]
    private float _speed = 2.2f;
    [SerializeField]
    private GameObject _Player;
    private GameObject _ShieldAura;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -5.4f)
        {
            transform.position = new Vector3(Random.Range(-9.7f, 9.7f), Random.Range(6.5f,9.7f), 0.0f);
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Object.Destroy(this.gameObject);
            Debug.Log("Shield powerup collected");
            Instantiate(_ShieldAura, new Vector3(other.transform.position.x, (other.transform.position.y) + .5f, 0), Quaternion.identity);
            

        }
    }


}
