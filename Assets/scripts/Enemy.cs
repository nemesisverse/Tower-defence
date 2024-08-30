using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int GOldReward = 25;
    [SerializeField] int GoldPenalty = 25;

    Bank bank;
    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        if (bank == null) { return; }
        bank.Deposit(GOldReward);
    }

    public void StealGold()
    {
        if (bank == null) { return; }
        bank.Withdraw(GoldPenalty);
    }

}
