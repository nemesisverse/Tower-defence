using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] int CostOfTower = 40;
    public bool CreateTower(Tower tower , Vector3 position)
    {

        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return false;
        }

        if(bank.CurrentBalance >= CostOfTower)
        {
            Instantiate(tower, position, Quaternion.identity);
            bank.Withdraw(CostOfTower -     10);
            return true;
        }

        return false;
    }
        
}
