using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletMovement : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * speed;
    }
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5f);
    }
}
