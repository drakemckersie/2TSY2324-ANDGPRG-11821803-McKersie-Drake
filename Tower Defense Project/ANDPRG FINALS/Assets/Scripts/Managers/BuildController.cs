using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildController : MonoBehaviour
{
    [SerializeField] float buildableOffsetY = 2;
    Ray ray; 
    [SerializeField] RaycastHit hit; // Object being hit
    [SerializeField] RaycastHit[] allObject;

    [SerializeField] GameObject[] prefabTowers; // list of prefab towers
    [SerializeField] GameObject draggableTower; // temp till tower is built
    [SerializeField] Tower tempTower;

    public void SpawnTower()
    {
        if (GameManager.Instance.currency < 500)
        {
            Debug.LogWarning("Insufficient Funds");
        }
        else
        {
            GameObject tempTwrObj = (GameObject)Instantiate(prefabTowers[0]);
            draggableTower = tempTwrObj;
            tempTower = tempTwrObj.GetComponent<Tower>();
            GameManager.Instance.SpendCurrency(500);
        }
    }

    public void SpawnTower1()
    {
        if (GameManager.Instance.currency < 250)
        {
            Debug.LogWarning("Insufficient Funds");
        }
        else
        {
            GameObject tempTwrObj = (GameObject)Instantiate(prefabTowers[1]);
            draggableTower = tempTwrObj;
            tempTower = tempTwrObj.GetComponent<Tower>();
            GameManager.Instance.SpendCurrency(250);
        }
    }
    public void SpawnTower2()
    {
        if (GameManager.Instance.currency < 500)
        {
            Debug.LogWarning("Insufficient Funds");
        }
        else
        {
            GameObject tempTwrObj = (GameObject)Instantiate(prefabTowers[2]);
            draggableTower = tempTwrObj;
            tempTower = tempTwrObj.GetComponent<Tower>();
            GameManager.Instance.SpendCurrency(500);
        }
    }
    public void SpawnTower3()
    {
        if (GameManager.Instance.currency < 600)
        {
            Debug.LogWarning("Insufficient Funds");
        }
        else
        {
            GameObject tempTwrObj = (GameObject)Instantiate(prefabTowers[3]);
            draggableTower = tempTwrObj;
            tempTower = tempTwrObj.GetComponent<Tower>();
            GameManager.Instance.SpendCurrency(600);
        }
    }

    Vector3 SnaptoGrid(Vector3 towerPos)
    {
        return new Vector3(Mathf.Round(towerPos.x),
            towerPos.y, Mathf.Round(towerPos.z));
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      //  allObject = Physics.RaycastAll(ray); // all object

      //  if (Physics.Raycast(ray, out hit))
     //   {
      //      Debug.Log(hit.point.y);
      //     Debug.DrawLine(ray.origin, hit.point);
     //   }

        if(draggableTower != null )
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit ) )
            {
                draggableTower.transform.position = SnaptoGrid(hit.point);
                if(hit.point.y > buildableOffsetY)
                {
                    tempTower.Buildable();
                    if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
                    {
                        tempTower.Build();
                        draggableTower = null;
                    }
                }
                else
                {
                    tempTower.NonBuildable();
                }
            }
        }
    }
}
