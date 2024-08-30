using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int poolsize = 5;
    [SerializeField] float SpawnTimer = 1f;
    GameObject[] pool;

   void Awake()
    {
        PopulatePool();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
         pool = new GameObject[poolsize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab , transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectPool()
    {
        for(int i = 0; i<pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive (true);
                return;
               
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectPool();
            yield return new WaitForSeconds(SpawnTimer);
        }
    }

 
}
