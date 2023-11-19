using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
  [SerializeField] int startingBalance = 150;

  [SerializeField] int currentBalance;
  public int CurrentBalance { get { return currentBalance; } }

  [SerializeField] TextMeshProUGUI displayBalance;


  void Awake()
  {
    currentBalance = startingBalance;
    UpdateDisplayBalance();
  }

  public void Deposit(int amount)
  {
    currentBalance += Mathf.Abs(amount);
    UpdateDisplayBalance();
  }

  public void Withdraw(int amount)
  {
    currentBalance -= Mathf.Abs(amount);
    UpdateDisplayBalance();

    if (currentBalance < 0) { ReloadScene(); }
  }

  void UpdateDisplayBalance()
  {
    displayBalance.text = "Gold: " + currentBalance;
  }

  void ReloadScene()
  {
    Scene scene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(scene.buildIndex);
  }
}
