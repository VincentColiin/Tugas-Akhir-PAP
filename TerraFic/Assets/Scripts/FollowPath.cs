using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowPath : MonoBehaviour
{

    enum junction
    {
        straight,
        left,
        right
    }

    [SerializeField] float minDist = 0.2f;
    [SerializeField] float maxSpeed = 0.01f;
    [SerializeField] Transform[] points = new Transform[2];
    [SerializeField] junction[] junctions;
    [SerializeField] GameObject trafficPost;
    [SerializeField] Transform stopPostition;
    [SerializeField] GameOverScript gameOverScript;
    GameObject car;
    private Vector3 velocity;
    private float time;
    private int i;
    private bool rotated;
    [SerializeField] float timeLimit = 5f;
    private float timeWaited;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverScript.getState() == 1)
        {
            if ((transform.position - stopPostition.position).magnitude > minDist
                ||
                trafficPost.GetComponent<TrafficPost>().getLight() == TrafficPost.Light.green)
            {
                moveCar();
            }
            else if (timeWaited < timeLimit)
            {
                timeWaited = timeWaited + Time.deltaTime;
            }
            else
            {
                moveCar();
            }

        }
    }


    private void moveCar()
    {
        if ((transform.position - points[i + 1].position).magnitude >= minDist)
        {
            time = (time + Time.deltaTime * maxSpeed);
            //transform.position = Vector3.Lerp(points[i].position, points[i + 1].position, time);
            velocity = velocity + adjustVelocity(transform.position, points[i + 1].position, time);
            transform.position = transform.position + velocity;

            if (i > 0 && !rotated)
            {
                switch (junctions[i - 1])
                {
                    case junction.left:
                        transform.rotation *= Quaternion.Euler(0, 0, 90);
                        rotated = true;
                        break;
                    case junction.right:
                        transform.rotation *= Quaternion.Euler(0, 0, -90);
                        rotated = true;
                        break;
                    default:
                        Debug.Log("junction bermasalah");
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameOverScript.onCollision();
    }

}