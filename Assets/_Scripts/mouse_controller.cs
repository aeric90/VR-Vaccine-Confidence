using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_controller : MonoBehaviour
{
    public float sensitivity = 0.3f;
    private Vector3 anchorPoint;
    private Quaternion anchorRot;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            anchorPoint = new Vector3(Input.mousePosition.y, -Input.mousePosition.x);
            anchorRot = transform.rotation;
        }

        if (Input.GetMouseButton(1))
        {
            Quaternion rot = anchorRot;
            Vector3 dif = anchorPoint - new Vector3(Input.mousePosition.y, -Input.mousePosition.x);
            rot.eulerAngles += dif * sensitivity;
            transform.rotation = rot;
        }
    }
}