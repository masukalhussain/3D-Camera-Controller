using UnityEngine;

public class CamControl : MonoBehaviour
{
    public float lookSpeedH = 1f;
    public float lookSpeedV = 1f;
    public float zoomSpeed = 2f;
    public float dragSpeed = 6f;
    public float panSpeed = 20f;

    private float yaw = 0f;
    private float pitch = 0f;

    void Update()
    {
        //Look around with Right Mouse
        if (Input.GetMouseButton(1))
        {
            yaw += lookSpeedH * Input.GetAxis("Mouse X");
            pitch -= lookSpeedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }

        //Movement with W,A,S,D

        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * (Time.deltaTime * panSpeed);
        }

        if (Input.GetKey("d"))
        {
            transform.position += transform.right * (Time.deltaTime * panSpeed);
        }

        if (Input.GetKey("a"))
        {
            transform.position -= transform.right * (Time.deltaTime * panSpeed);
        }

        if (Input.GetKey("s"))
        {
            transform.position -= transform.forward * (Time.deltaTime * panSpeed);
        }

        //Zoom in and out with Mouse Wheel
        transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, Space.Self);
    }
}
