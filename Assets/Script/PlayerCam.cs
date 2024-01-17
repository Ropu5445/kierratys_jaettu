using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    [SerializeField] private Transform orientation;

    private float xRotation;
    private float yRotation;

    public bool isMoving = false;
    public float movementStartTime;
    public float movementDuration;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Hiiren inputin ottaminen.
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Kameran ja orientaation kiertäminen.
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);


        //liikkuuko kamera
        if (mouseX != 0 || mouseY != 0)
        {
            if (!isMoving)
            {
                isMoving = true;
                movementStartTime = Time.unscaledTime;

            }
        }
        else
        {
            if (isMoving)
            {
                if (movementDuration < 1)
                {
                    isMoving = false;
                    movementDuration += Time.unscaledTime - movementStartTime;
                }
                
            }
        }

    }


}
