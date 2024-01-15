using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 5;
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position -= new Vector3(0, 0, 1) * Time.deltaTime * speed;
        }
    }
}
