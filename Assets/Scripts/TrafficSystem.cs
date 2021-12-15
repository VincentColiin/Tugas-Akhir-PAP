using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSystem : MonoBehaviour
{

    [SerializeField] GameObject[] trafficPostsObject = new GameObject[1];
    TrafficPost[] trafficPosts;
    private int currentGreen;
    private int nextGreen;

    // Start is called before the first frame update
    void Start()
    {
        initLights();
    }

    void initLights()
    {
        trafficPosts = new TrafficPost[trafficPostsObject.Length];
        for (int i = 0; i < trafficPostsObject.Length; i++)
        {
            trafficPosts[i] = trafficPostsObject[i].GetComponent<TrafficPost>();
        }
        trafficPosts[0].updateLights();
    }

    // Update is called once per frame
    void Update()
    {
        nextGreen = GetPressedNumber();
        if(currentGreen != nextGreen && nextGreen != -1)
        {
            trafficPosts[currentGreen].updateLights();
            trafficPosts[nextGreen].updateLights();
            currentGreen = nextGreen;
        }
    }

    public int GetPressedNumber()
    {
        for (int number = 0; number <= trafficPostsObject.Length; number++)
        {
            if (Input.GetKeyDown(number.ToString()))
                return number-1;
        }

        return -1;
    }

}
