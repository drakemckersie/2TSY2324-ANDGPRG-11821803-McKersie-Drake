using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject crystalCore;
    public GameObject CrystalCore { get { return crystalCore; } }

    //
    public int currency;
    //

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currency = 500;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("Insufficient Funds.");
            return false;
        }
    }
  }
