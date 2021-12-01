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
    [SerializeField] float speed=0.1f;
    [SerializeField] Transform[] points=new Transform[2];
    [SerializeField] rotate[] rotates;
    GameObject car;
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
        if ((transform.position - points[i+1].position).magnitude >= minDist)
        {
            time = (time + Time.deltaTime * speed);
            transform.position = Vector3.Lerp(points[i].position, points[i + 1].position, time);

            if (i>0 && !rotated)
            {
                switch (rotates[i-1])
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
        } else if(i<points.Length-2)
        {
            i++;
            rotated = false;
            time = 0;
        }
    }
}
