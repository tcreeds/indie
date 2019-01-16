using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    private float speedMultiplier = 1.5f;
    private float rotateMultiplier = 0.2f;
    private float rotateThreshold = 0.05f;
    
    private Vector3 lastMousePosition;
    private GameObject cameraContainerX;
    private GameObject cameraContainerY;


	// Use this for initialization
	void Start () {
        cameraContainerX = GameObject.Find("CameraContainerX");
        cameraContainerY = GameObject.Find("CameraContainerY");
        lastMousePosition = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 mousePosition = Input.mousePosition;

        float dx = mousePosition.x - lastMousePosition.x;
        float dy = mousePosition.y - lastMousePosition.y;


        if (Input.GetMouseButton(1))
        {
            if (Mathf.Abs(dx) > rotateThreshold)
            {
                transform.Rotate(Vector3.up, dx * rotateMultiplier);
                transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
                cameraContainerX.transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
            }
            if (Mathf.Abs(dy) > rotateThreshold)
            {
                cameraContainerY.transform.Rotate(Vector3.right, -dy * rotateMultiplier);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (Mathf.Abs(dx) > rotateThreshold)
            {
                cameraContainerX.transform.Rotate(Vector3.up, dx * rotateMultiplier);
            }
            cameraContainerX.transform.rotation = Quaternion.LookRotation(cameraContainerX.transform.forward, Vector3.up);
            if (Mathf.Abs(dy) > rotateThreshold)
            {
                cameraContainerY.transform.Rotate(Vector3.right, -dy * rotateMultiplier);
            }
        }

        if (Input.GetKey(KeyCode.W)) {
            transform.position = transform.position + (transform.forward * speedMultiplier) * Time.deltaTime;
            if (!Input.GetMouseButton(0))
            { 
                cameraContainerX.transform.rotation = Quaternion.Lerp(cameraContainerX.transform.rotation, Quaternion.LookRotation(transform.forward, Vector3.up), 0.1f);
            }
        }
        if (Input.GetKey(KeyCode.A)) {

            transform.position = transform.position - (transform.right * speedMultiplier) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.position = transform.position + (transform.right * speedMultiplier) * Time.deltaTime;
        }
        

        lastMousePosition = mousePosition;
    }
}

