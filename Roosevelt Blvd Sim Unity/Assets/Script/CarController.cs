using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;



public class CarController : MonoBehaviour
{
    // Start is called before the first frame update
    private MeshRenderer[] wheelMesh;
    private WheelCollider[] wheel;
    private float maxAngle;
    private float maxToque;
    private float h, v;
    void Start()
    {
        maxAngle = 30;
        maxToque = 200;
        wheelMesh = transform.GetChild(2).GetComponentsInChildren < MeshRenderer > ();
        wheel = transform.GetChild(1).GetComponentsInChildren < WheelCollider > ();
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        if (0 == Mathf.Abs(h) && 0 == Mathf.Abs(v)) return;
  
        Move();
        
    }

    private void Move()
    {
        for (int i = 0; i < 2; i++)
        {
            wheel[i].steerAngle = h * maxAngle;
        }
        foreach (var o in wheel)
        {
            o.motorTorque = maxToque * v;
            Debug.Log("Before accessing array at line 33" + o.motorTorque);
        }
        for (int i = 0; i < 4;i++)
        {
            wheelMesh[i].transform.localRotation = Quaternion.Euler(wheel[i].rpm * 360 / 60, wheel[i].steerAngle, 0);
        }
    }

}

