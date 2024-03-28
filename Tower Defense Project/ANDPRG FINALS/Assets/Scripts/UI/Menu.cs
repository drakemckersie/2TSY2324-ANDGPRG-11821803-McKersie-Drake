using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Menu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] TextMeshProUGUI crystalHealth;
    [SerializeField] TextMeshProUGUI waveCounter;
    // CrystalHealth health;
    private void OnGUI()
    {
        currencyUI.text = GameManager.Instance.currency.ToString();
        crystalHealth.text = GameManager.Instance.hitPoints.ToString();
        waveCounter.text = SpawnerController.Instance.currentWave.ToString();
    }
}
