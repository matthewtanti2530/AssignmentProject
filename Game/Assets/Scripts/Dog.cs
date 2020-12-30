using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
private float _speed = 5f;
private Rigidbody rb;
private bool DogIsOnTheGround = true;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

        transform.Translate(horizontal, 0f, vertical);

        if(Input.GetButtonDown("Jump") && DogIsOnTheGround)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            DogIsOnTheGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            DogIsOnTheGround = true;
        }
    }
}
