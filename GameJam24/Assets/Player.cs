using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    new
        // Start is called before the first frame update
        Rigidbody rigidbody;

    float moveSpeed = 3.5f;
    float jumpHeight = 10f;

    float jumpCD = 0;

    bool present = false;

    bool highJump = false;
    bool sprint = false;
    bool breakObjects = false;
    bool glide = false;
    private bool attacking;
    private object animationController;
    private object particlePrefab;

    public Text dialogue;
    public GameObject dialogueBox;
    private static Vector3 position;

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
            jumpHeight = 15f;
        }
        else
        {
            jumpHeight = 13f;
        }

        if (sprint && Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 6f;
        }
        else
        {
            moveSpeed = 3.5f;
        }

        if (glide && Input.GetKey(KeyCode.Space) && rigidbody.velocity.y < 0)
        {
            Vector3 glideVel = rigidbody.velocity;
            glideVel.y = -2f;

            rigidbody.velocity = glideVel;
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

        if (Input.GetKeyDown(KeyCode.Space) && Physics.SphereCast(transform.position, 0.4f, Vector3.down, out _, 0.7f) && jumpCD >= 0)
        {
            rigidbody.velocity = Vector3.zero;
            jumpCD = 0.25f;
            rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
        }

        if (jumpCD > 0.2f)
        {
            jumpCD -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(transform.position,transform.forward,out RaycastHit hit,2f))
            {
                if (hit.collider.gameObject.tag == "Breakable door")
                {
                    Destroy(hit.collider.gameObject);
                }

            }
        }
    }
}