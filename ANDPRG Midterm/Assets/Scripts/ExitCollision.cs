using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitCollision : MonoBehaviour
{
    public string LevelName;
    
  //public int LevelIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }
  void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            
            SceneManager.LoadScene(LevelName);
     
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
