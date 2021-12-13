using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowPath : MonoBehaviour
{

    enum rotate
    {
        left,
        right
    }

    [SerializeField] float minDist = 0.2f;
    [SerializeField] float maxSpeed = 0.01f;
    [SerializeField] Transform[] points = new Transform[2];
    [SerializeField] rotate[] rotates;
    GameObject car;
    private Vector3 velocity;
    private float time;
    private int i;
    private bool rotated;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Masih perlu diganti agar bisa dipake untuk semua mobil
        if ((transform.position - points[i + 1].position).magnitude >= minDist)
        {
            time = (time + Time.deltaTime * maxSpeed);
            //transform.position = Vector3.Lerp(points[i].position, points[i + 1].position, time);
            velocity = velocity + adjustVelocity(transform.position, points[i + 1].position, time);
            transform.position = transform.position + velocity;

            if (i > 0 && !rotated)
            {
                switch (rotates[i - 1])
                {
                    case rotate.left:
                        transform.rotation *= Quaternion.Euler(0, 0, 90);
                        rotated = true;
                        break;
                    case rotate.right:
                        transform.rotation *= Quaternion.Euler(0, 0, -90);
                        rotated = true;
                        break;
                    default:
                        break;
                }
            }
        }
        else if (i < points.Length - 2)
        {
            i++;
            rotated = false;
            time = 0;
        }
    }

    private Vector3 adjustVelocity(Vector3 position, Vector3 target, float time)
    {
        Vector3 steer;
        Vector3 desirePosition = target - position;
        float speed = maxSpeed;
        if (desirePosition.magnitude < minDist)
        {
            speed = Map(desirePosition.magnitude, 0, minDist, 0, maxSpeed);
        }
        desirePosition = desirePosition.normalized * speed;
        steer = desirePosition - velocity;
        return steer;
    }

    private float Map(float value, float inputLow, float inputHigh, float outputLow, float outputHigh)
    {
        return outputLow + (value - outputLow) * (outputHigh - outputLow) / (inputHigh - inputLow);
    }

}
