using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficPost : MonoBehaviour
{
    public enum Light
    {
        red,
        green
    }

    new Light light = Light.red;
    SpriteRenderer trafficRenderer;
    // Start is called before the first frame update
    void Start()
    {
        trafficRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (light)
        {
            case Light.red:
                trafficRenderer.color = Color.red;
                break;
            case Light.green:
                trafficRenderer.color = Color.green;
                break;
            default:
                trafficRenderer.color = Color.white;
                break;
        }
    }

    public Light getLight()
    {
        return light;
    }

    public void updateLights()
    {
        switch (light)
        {
            case Light.red:
                light = Light.green;
                break;
            case Light.green:
                light = Light.red;
                break;
            default:
                Debug.Log("updateLight bermasalah");
                break;
        }
    }

}
