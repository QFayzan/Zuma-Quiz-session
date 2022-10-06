using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    private Transform[] target;
    public float speed = 2;
    public int current;
    private WaypointCoordinates  coordinates; 

    void Start()
    {
        coordinates = GameObject.Find("Waypoints").GetComponent<WaypointCoordinates>();
        target = coordinates.waypoints;
    }
    void Update()
    {
        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position , target[current].position, speed*Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else current =  (current + 1) % target.Length;

        if( transform.position ==  target[target.Length-1].transform.position)
        {
            Destroy(gameObject);
            Time.timeScale =2;
        }

    }

}
