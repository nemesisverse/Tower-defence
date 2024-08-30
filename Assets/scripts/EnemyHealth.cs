using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int MaxHitPoints = 5;
    [SerializeField] int CurrentHitPoints = 0;

    Enemy enemy;

     void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        CurrentHitPoints = MaxHitPoints;
    }

    // Update is called once per frame
     void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        CurrentHitPoints--;
        if(CurrentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            MaxHitPoints += 1;
            enemy.RewardGold();
        }
    }
}
