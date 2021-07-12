using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayer : MonoBehaviour
{
    private float moveSpeed = 400f;
    private float moveSpeedMob = 400f;

    private void Update()
    {
        //Android
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                transform.RotateAround(Vector3.zero, Vector3.forward, -4f * Time.fixedDeltaTime * -moveSpeedMob);
            }
            else if (touch.position.x > Screen.width / 2)
            {
                transform.RotateAround(Vector3.zero, Vector3.back, 4f * Time.fixedDeltaTime * +moveSpeedMob);
            }
        }

        //UnityEditor
        if (Input.GetKey(KeyCode.A))
        {

                transform.RotateAround(Vector3.zero, Vector3.forward, -1f * Time.fixedDeltaTime * -moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(Vector3.zero, Vector3.back, 1f * Time.fixedDeltaTime * +moveSpeed);
        }
    }
}
