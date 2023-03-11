using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //for camera rotation
    private Quaternion cameraSocketRotation;
    public float cameraSocketRotationSpeed;
    public float cameraSocketRotationUpMax;
    public float cameraSocketRotationDownMax;


    // Awake is called before the first frame update
    void Awake()
    {
        //for camera rotation
        cameraSocketRotation = transform.rotation;
        
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        //for camera rotation
        //set rotation up and down and left and right to camera socket
        cameraSocketRotation.x += (Input.GetAxis("Mouse Y") * -1) * cameraSocketRotationSpeed;
        cameraSocketRotation.y += (Input.GetAxis("Mouse X")) * cameraSocketRotationSpeed;


        cameraSocketRotation.x = Mathf.Clamp(cameraSocketRotation.x, cameraSocketRotationUpMax, cameraSocketRotationDownMax);
        transform.rotation = Quaternion.Euler(cameraSocketRotation.x, cameraSocketRotation.y, cameraSocketRotation.z);
    }
}
