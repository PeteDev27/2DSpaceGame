using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour
{
    [SerializeField]
    private float _laserspeed = 11.3f;
    [SerializeField]
    private GameObject _Tripleshot;
    [SerializeField]
    private GameObject _Enemyship;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * _laserspeed * Time.deltaTime);
        if (transform.position.y >= 10)
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Tri-Laser fired");
        }
        else if (other.tag == "Enemies")
        {
            Object.Destroy(this.gameObject);
            Object.Destroy(other.gameObject);
            

        }
    }

}