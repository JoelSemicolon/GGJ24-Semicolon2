using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidbody;

    float moveSpeed = 5f;

    bool highJump = false;
    bool sprint = false;
    bool breakObjects = false;
    bool glide = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (highJump)
            {
                highJump = false;
            }
            else
            {
                highJump = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (sprint)
            {
                sprint = false;
            }
            else
            {
                sprint = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (breakObjects)
            {
                breakObjects = false;
            }
            else
            {
                breakObjects = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (glide)
            {
                glide = false;
            }
            else
            {
                glide = true;
            }
        }

        if (Input.GetKey(KeyCode.W) && !Physics.BoxCast(transform.position, new Vector3(0.49f, 0.99f, 0.49f), Vector3.forward, Quaternion.identity, 0.1f))
        {
            rigidbody.MovePosition(rigidbody.position + transform.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) && !Physics.BoxCast(transform.position, new Vector3(0.49f, 0.99f, 0.49f), Vector3.left, Quaternion.identity, 0.1f))
        {
            rigidbody.MovePosition(rigidbody.position - transform.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && !Physics.BoxCast(transform.position, new Vector3(0.49f, 0.99f, 0.49f), Vector3.back, Quaternion.identity, 0.1f))
        {
            rigidbody.MovePosition(rigidbody.position - transform.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && !Physics.BoxCast(transform.position, new Vector3(0.49f, 0.99f, 0.49f), Vector3.right, Quaternion.identity, 0.1f))
        {
            rigidbody.MovePosition(rigidbody.position + transform.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Physics.BoxCast(transform.position, new Vector3(0.49f, 0.99f, 0.49f), Vector3.down, Quaternion.identity, 0.1f))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(Vector3.up * 10f, ForceMode.VelocityChange);
        }
    }
}
