using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject _Player;
    [SerializeField]
    private GameObject _Enemyship;
    [SerializeField]
    private GameObject _Heavyship;
    [SerializeField]
    private GameObject _Shieldpower;
    [SerializeField]
    private GameObject _EnemyContainer;
    [SerializeField]
    private GameObject _TripleShotPowerUp;
    [SerializeField]
    private GameObject _PowerupsContainer;
    private bool _Shipsalive = true;
    public int ShipLives = 4;
    public void Laserupgrade()
    {

    }

    void Start()
    {
        StartCoroutine(EnemyShipSpawn());
        StartCoroutine(PowerUpsSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator EnemyShipSpawn()
    {
        while (_Shipsalive == true)
        {
           GameObject newEnemy = Instantiate(_Enemyship.gameObject, new Vector3(Random.Range(-9.7f, 9.7f), 7.5f, 0.0f), Quaternion.identity);
             newEnemy.transform.parent = _EnemyContainer.transform;
            yield return new WaitForSeconds(Random.Range(2.9f, 5.3f));
           
            GameObject newEnemy2 = Instantiate(_Heavyship.gameObject, new Vector3(Random.Range(-9.7f, 9.7f), 7.5f, 0.0f), Quaternion.identity);
            newEnemy2.transform.parent = _EnemyContainer.transform;
            yield return new WaitForSeconds(Random.Range(3.3f, 5.3f));
        
        }
    }

    IEnumerator PowerUpsSpawn()
    {
        while (_Player.activeSelf)
        {
            GameObject LaserPowerUp = Instantiate(_TripleShotPowerUp.gameObject, new Vector3(Random.Range(-9.7f, 9.7f), Random.Range(7.5f, 9.7f), 0.0f), Quaternion.identity);
            LaserPowerUp.transform.parent = _PowerupsContainer.transform;
            yield return new WaitForSeconds(3.7f);
        }    
    }

    public void OnPlayerDeath()
    {
        if (ShipLives <= 0)
        {
            _Shipsalive = false;
        }
    }
    
}
