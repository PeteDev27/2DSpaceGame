using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAura : MonoBehaviour
{
    [SerializeField]
    private GameObject _Player;
    [SerializeField]
    private GameObject _Shieldaura;
    // Start is called before the first frame update
    void Start()
    {
          

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_Player.transform.position.x, _Player.transform.position.y + .7f, _Player.transform.position.z);
    }
}
