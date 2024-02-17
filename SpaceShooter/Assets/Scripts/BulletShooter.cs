using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletShooter : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public Transform i;
    public GameObject o;

    public Transform nozzle1;
    public Transform nozzle2;
    public Transform nozzle3;
    public Transform nozzle4;

    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public GameObject bulletPrefab4;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(o, i.transform.position, i.rotation);
            source.PlayOneShot(clip);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            i = nozzle1;
            o = bulletPrefab1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            i = nozzle2;
            o = bulletPrefab2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            i = nozzle3;
            o = bulletPrefab3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            i = nozzle4;
            o = bulletPrefab4;
        }

       

          // if (Input.GetKeyDown(KeyCode.Alpha1))
          //  {

            //      Instantiate(bulletPrefab1, nozzle1.transform.position, nozzle1.rotation);

            // }
            // if (Input.GetKeyDown(KeyCode.Alpha2))
            // {

            //         Instantiate(bulletPrefab2, nozzle2.transform.position, nozzle2.rotation);
            // }
            //  if (Input.GetKeyDown(KeyCode.Alpha3))
            // {

            //         Instantiate(bulletPrefab3, nozzle3.transform.position, nozzle3.rotation);
            // }
            // if (Input.GetKeyDown(KeyCode.Alpha4))
            //{

            //         Instantiate(bulletPrefab4, nozzle4.transform.position, nozzle4.rotation);
            //}

    }
}