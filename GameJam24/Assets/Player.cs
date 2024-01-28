using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
        // Start is called before the first frame update
    Rigidbody rigidbody;

    float moveSpeed = 3.5f;
    float jumpHeight = 10f;

    float jumpCD = 0f;

    bool present = false;

    int presents = 0;

    float dialogueActive = 0f;
    float timer = 0f;
    string text;

    bool breakObjects = false;
    bool glide = false;

    private bool attacking;
    private object animationController;
    private object particlePrefab;

    public TMP_Text dialogue;
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
            if (jumpHeight == 15f)
            {
                jumpHeight = 10f;
            }
            else
            {
                jumpHeight = 15f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (moveSpeed == 6f)
            {
                moveSpeed = 3.5f;
            }
            else
            {
                moveSpeed = 6f;
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

        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                dialogue.text = text;
            }
        }

        if (dialogueActive > 0f)
        {
            dialogueActive -= Time.deltaTime;
            if (dialogueActive <= 0)
            {
                dialogueBox.SetActive(false);
            }
        }

        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!Physics.Raycast(origin:position,Vector3.forward))
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "dialogue" && present)
        {
            if (presents == 0)
            {
                present = false;
                jumpHeight = 15f;
                dialogue.text = "Thanks for the first present.";
                text = "Here's something in return, it lets you jump higher!";
                timer = 5f;
                dialogueActive = 10f;
                dialogueBox.SetActive(true);
                presents += 1;
            }
            else if (presents == 1)
            {
                present = false;
                moveSpeed = 6f;
                dialogue.text = "Thanks for the second present.";
                text = "Here's something in return, it lets you run faster!";
                timer = 5f;
                dialogueActive = 10f;
                dialogueBox.SetActive(true);
                presents += 1;
            }
            else if (presents == 2)
            {
                present = false;
                breakObjects = true;
                dialogue.text = "Thanks for the third present.";
                text = "Here's something in return, it lets you break walls!";
                timer = 5f;
                dialogueActive = 10f;
                dialogueBox.SetActive(true);
                presents += 1;
            }
            else if (presents == 3)
            {
                present = false;
                glide = true;
                dialogue.text = "Thanks for the forth present.";
                text = "Here's something in return, it lets you glide in the air by holding down space!";
                timer = 5f;
                dialogueActive = 10f;
                dialogueBox.SetActive(true);
                presents += 1;
            }
            else if (presents == 4)
            {
                present = false;
                dialogue.text = "Thanks for the fifth present.";
                text = "Wow this is amazing, thanks for cheering me up!";
                timer = 5f;
                dialogueActive = 10f;
                dialogueBox.SetActive(true);
                presents += 1;
            }
        }
    }
}
