using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledCamera : MonoBehaviour {

    public float speed = 50f;
    public float rotationSpeed = 2;
    public bool hasControl;
    private Vector3 mouseRotationOffset;
	// Use this for initialization
	void Start () {
        mouseRotationOffset = new Vector3(0, 0, 0);
	}
	
    public void GiveControl()
    {
        hasControl = true;
    }
	// Update is called once per frame
	void Update () {
        if (hasControl)
        {
            Cursor.lockState = CursorLockMode.Locked;
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += transform.forward * -1 * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += transform.right * -1 * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * 1 * speed * Time.deltaTime;
            }

            mouseRotationOffset.x += -1 * Input.GetAxis("Mouse Y") * rotationSpeed;
            mouseRotationOffset.y += Input.GetAxis("Mouse X") * rotationSpeed;

            transform.rotation = Quaternion.Euler(mouseRotationOffset);
        }
        else{
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
