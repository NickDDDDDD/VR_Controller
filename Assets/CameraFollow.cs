using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    // 目标物体
    public Vector3 offset;      // 相对于目标物体的偏移量
    public bool shouldFollow = false; // 是否应该跟随目标物体

    // Update is called once per frame
    void Update()
    {
        if (shouldFollow)
        {
            // 设置摄像机的位置等于目标物体的位置加上偏移量
            transform.position = target.position + offset;
        }
        else
        {
            // 这里添加手柄控制的代码
            // 例如：
            // float horizontalInput = Input.GetAxis("Horizontal");
            // float verticalInput = Input.GetAxis("Vertical");
            // transform.Translate(new Vector3(horizontalInput, 0, verticalInput));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 如果摄像机接触到的物体是目标物体
        if (other.transform == target)
        {
            // 开始跟随目标物体
            shouldFollow = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // 如果摄像机离开的物体是目标物体
        if (other.transform == target)
        {
            // 停止跟随目标物体
            shouldFollow = false;
        }
    }
}
