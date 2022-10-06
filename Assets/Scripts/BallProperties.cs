using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallProperties : MonoBehaviour
{
    Ray front;
    Ray back;
    // Start is called before the first frame update
    void Start()
    {
        front = new Ray( transform.position + Vector3.forward , transform.forward);
        back = new Ray (transform.position + Vector3.back , transform.forward);
        Debug.DrawRay(transform.position , Vector3.forward , Color.red, 30.0f);
        Debug.DrawRay(transform.position , Vector3.back , Color.blue, 30.0f);
        //sets a color at the start of being spawned
        int i =0;
        i = Random.Range(0,5);
        {
            if (i == 0)
            {
                GetComponent<Renderer>().material.color = Color.black;
            }
            if (i == 1)
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
            if (i == 2)
            {
                GetComponent<Renderer>().material.color = Color.blue;
            }
            if (i == 3)
            {
                GetComponent<Renderer>().material.color = Color.green;
            }
            if(i == 4)
            {
                GetComponent<Renderer>().material.color = Color.magenta;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //destroy all in sphere cast is material. color match
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            return ;
        }
    }
    void SideValues()
    {
        
    }
}
   /* void FindSame(GameObject obj)
    {

         Collider[] colliders =  Physics.OverlapSphere(transform.position , 3.0f);
         foreach(  Collider nearbyBalls in colliders)
         {
            int hit = 0;
            Renderer rd = GetComponent<Renderer>();
            if(rd.material.color == obj.GetComponent<Renderer>().material.color)
            {
                hit++;
            }
            if (hit>3)
            {
                Destroy(nearbyBalls);
                Debug.Log("3 same color" + rd.material.color);
            }

         }
            //renderer.material.color
          //  Debug.Log(rd.material.color);
        
            
         }
         
         
}
*/
