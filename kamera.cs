using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    private float mouseX, mouseY;

    private Transform parent, target;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
        // target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!HUDManager.GameIsPaused){
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            parent.Rotate(Vector3.up, mouseX);
        }
        
        // mouseX += Input.GetAxis("Mouse X") * sensitivity;
        // mouseX -= Input.GetAxis("Mouse Y") * sensitivity;

        // mouseY = Mathf.Clamp(mouseY, -36, 60);
        // transform.LookAt(target);
        // target.rotation = Quaternion.Euler(mouseY,mouseX, 0);
        // parent.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
