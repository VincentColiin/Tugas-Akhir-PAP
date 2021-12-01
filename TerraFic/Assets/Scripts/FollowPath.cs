using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] Transform[] checkpoint;
    [SerializeField] Transform car;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Masih perlu diganti agar bisa dipake untuk semua mobil
        time =(time + Time.deltaTime*speed)%1f;
        car.position = Vector3.Lerp(checkpoint[0].position, checkpoint[1].position, time);
    }
}
