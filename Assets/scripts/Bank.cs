using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int StartingBalance = 150;

    [SerializeField] int currentBalance;
   public int CurrentBalance { get { return currentBalance; } }

    [SerializeField] TextMeshProUGUI GoldBalanceUI;

    void Awake()
    {

        currentBalance = StartingBalance;
        UpdateUI();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateUI();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateUI();

        if (CurrentBalance <0)
        {
            ReloadScene();
        }
    }

    void UpdateUI()
    {
        GoldBalanceUI.text = "Gold: " + currentBalance.ToString();
    }    

    void ReloadScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
