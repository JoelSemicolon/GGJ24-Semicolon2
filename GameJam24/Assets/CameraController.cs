using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    float rotX = 0f;
    float rotY = 0f;

    float rotateSpeed = 2f;
    float distance = 6f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rotX -= Input.GetAxis("Mouse Y") * rotateSpeed;
        rotY += Input.GetAxis("Mouse X") * rotateSpeed;
        rotX = Mathf.Clamp(rotX, -10f, 90f);
        transform.rotation = Quaternion.Euler(rotX, rotY, 0f);
        transform.position = target.transform.position - transform.forward * distance + Vector3.up * 2.5f;
    }
}
