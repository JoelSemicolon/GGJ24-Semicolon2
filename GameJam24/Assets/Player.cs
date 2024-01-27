using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidbody;

    float movespeed = 5f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.MovePosition(rigidbody.position + transform.forward * movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.MovePosition(rigidbody.position - transform.right * movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.MovePosition(rigidbody.position - transform.forward * movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.MovePosition(rigidbody.position + transform.right * movespeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * 10f, ForceMode.VelocityChange);
        }
    }
}
