using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject crystalCore;
    public GameObject CrystalCore { get { return crystalCore; } }

    //
    public int currency;

    public float hitPoints = 100f;
    string currentSceneName;
    //

    private void Awake()
    {
        Instance = this;
        string currentSceneName = SceneManager.GetActiveScene().name;
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

    public void TakeDamage(float dmg)
   {
       hitPoints -= dmg;

          if (hitPoints <= 0)
          {
             SceneManager.LoadScene("GameScene");
         }
      }

}
