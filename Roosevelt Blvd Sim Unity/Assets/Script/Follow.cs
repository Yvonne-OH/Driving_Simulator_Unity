using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform targetPos;//跟随的目标
    private Vector3 offsetPos;//固定位置
    private Vector3 tempPos;//临时变量
    void Start()
    {
        offsetPos = new Vector3(0f, 2f, -3.8f);
        targetPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("myObject: " + GameObject.FindGameObjectWithTag("Player"));
        tempPos = targetPos.position + targetPos.TransformDirection(offsetPos);
        transform.position = Vector3.Lerp(transform.position, tempPos, Time.fixedDeltaTime);
        transform.LookAt(targetPos);
    }
}





