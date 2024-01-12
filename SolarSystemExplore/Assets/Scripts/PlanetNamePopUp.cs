using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetNamePopUp : MonoBehaviour
{
    public GameObject PlanetName;

    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
     if(PlanetName.activeInHierarchy == false)  {
            PlanetName.SetActive(true);
        }
        else
        {
            PlanetName.SetActive(false);
        }
        
    }
    void Update()
    {

    }
}
