using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spherePrefab;
    public List<GameObject> enemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBall" , 0.5f, 1f);
       
        // GetComponent<Renderer>().material.color = Color.red;
       // GetComponent<Renderer>().material.color = Color.blue;
       // GetComponent<Renderer>().material.color = Color.green;
       // GetComponent<Renderer>().material.color = Color.black;
    }
    void SpawnBall()
    {
        Instantiate(spherePrefab, transform.position , Quaternion.identity);
        enemies.Add(spherePrefab);
    }
}
