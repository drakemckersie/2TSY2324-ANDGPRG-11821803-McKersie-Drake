using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    public AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position -= new Vector3(0, 0, 1) * Time.deltaTime * movementSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            source.PlayOneShot(clip);
            SceneManager.LoadScene("RetryScene");
        }
    }
}
