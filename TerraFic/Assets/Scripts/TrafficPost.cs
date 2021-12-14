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
    SpriteRenderer redRenderer;
    SpriteRenderer greenRenderer;
    // Start is called before the first frame update
    void Start()
    {
        redRenderer = this.transform.Find("redLight").GetComponent<SpriteRenderer>();
        greenRenderer = this.transform.Find("greenLight").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (light)
        {
            case Light.red:
                redRenderer.color = new Color(1f, 0, 0, 1f);
                greenRenderer.color = new Color(0, 1f, 0, 0.25f);
                break;
            case Light.green:
                redRenderer.color = new Color(1f, 0, 0, 0.25f);
                greenRenderer.color = new Color(0, 1f, 0, 1f);
                break;
            default:
                redRenderer.color = new Color(1f, 0, 0, 0.25f);
                greenRenderer.color = new Color(0, 1f, 0, 0.25f);
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
