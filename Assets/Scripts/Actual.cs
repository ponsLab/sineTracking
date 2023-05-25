using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actual : MonoBehaviour
{
    public float rotateAngle;
    private Quaternion targetRotation;
    private float origionz;

    // Start is called before the first frame update
    void Start()
    {
        origionz = -90;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotateAngle = Communication.receivedPos.y;
        targetRotation = Quaternion.Euler(0, 0, rotateAngle + origionz) * Quaternion.identity;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 100);
        if (Quaternion.Angle(targetRotation, transform.rotation) < 1)
        {
            transform.rotation = targetRotation;
        }
    }

}
