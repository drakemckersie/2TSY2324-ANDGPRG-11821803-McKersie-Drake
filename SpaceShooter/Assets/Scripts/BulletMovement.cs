using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletMovement : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public float speed = 10;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * speed;
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            source.PlayOneShot(clip);
        }
    }
    void Update()
    {
        Destroy(gameObject, 5f);
    }

    
}
