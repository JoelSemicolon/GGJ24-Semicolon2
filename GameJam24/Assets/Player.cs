using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidbody;

    float moveSpeed = 5f;
    float jumpHeight = 10f;

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

        if (highJump)
        {
            jumpHeight = 13f;
        }
        else
        {
            jumpHeight = 10f;
        }

        if (sprint && Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 6f;
        }
        else
        {
            moveSpeed = 4f;
        }

        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0f;
        if (forward.sqrMagnitude > 0f)
        {
            forward.Normalize();
        }
        Vector3 right = Camera.main.transform.right;
        right.y = 0f;
        if (right.sqrMagnitude > 0f)
        {
            right.Normalize();
        }

        Vector3 moveDirection = Vector3.zero;

        float sideMove = Input.GetAxisRaw("Horizontal");
        float forwardMove = Input.GetAxisRaw("Vertical");

        moveDirection += forward * forwardMove;
        moveDirection += right * sideMove;

        rigidbody.MovePosition(rigidbody.position + moveDirection * moveSpeed * Time.deltaTime);

        transform.rotation = Quaternion.LookRotation(forward);

        if (Input.GetKeyDown(KeyCode.Space) && Physics.BoxCast(transform.position, new Vector3(0.49f, 0.99f, 0.49f), Vector3.down, Quaternion.identity, 0.2f))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
        }
    }
}
