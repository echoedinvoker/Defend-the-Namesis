using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
  [SerializeField] int cost = 75;
  Bank bank;

  // public void CreateTower(Vector3 position)
  public bool CreateTower(Vector3 position)
  {
    bank = FindObjectOfType<Bank>();

    if (!bank) { return false; }

    if (bank.CurrentBalance >= cost)
    {
      Instantiate(gameObject, position, Quaternion.identity);
      bank.Withdraw(cost);
      return true;
    }

    return false;
  }
}
