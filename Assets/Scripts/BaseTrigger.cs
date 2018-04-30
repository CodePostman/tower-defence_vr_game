using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrigger : MonoBehaviour {

    public Enemy enemy;
    public int baseLives = 5;
    private SpawnManager _spawnManager;


    private void Start()
    {
        _spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(EnemyEntersTheBase());
            Destroy(other.gameObject, 3);
        }
       
    }

    IEnumerator EnemyEntersTheBase()
    {
        yield return new WaitForSeconds(2);
        baseLives--;
        _spawnManager.EnemyDefeated();
    }

}
