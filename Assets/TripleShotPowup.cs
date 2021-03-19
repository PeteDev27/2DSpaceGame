using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotPowup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 1.5f;
    public bool _Laserupgrade = false;
    void Start()
    {
        transform.position = new Vector3(Random.Range(-9.7f, 9.7f), Random.Range(4.3F, 5.5f), 0.0f);

       
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector3.down * _speed * Time.deltaTime);
    
        if (transform.position.y <= -5.4f)
        {
            transform.position = new Vector3(Random.Range(-9.7f, 9.7f), Random.Range(7.5f, 8.7f), 0.0f);
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }
    }
    public void Laserupgrade()
    {
        _Laserupgrade = true;
    }



}
