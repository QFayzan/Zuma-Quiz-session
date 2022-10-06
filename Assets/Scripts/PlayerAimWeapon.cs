using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;            //used by codemonkey
    
    public GameObject[] bullet;                  //the "bullets" mechanic
    public GameObject bulletSpawnPoint;        //Making a nested empty object to use its transform for coordinates
    private bool doShoot = true;
    float shootTimer = 0;
    private void Awake()
    {
        aimTransform = transform.Find("Aim"); //Codemonkey way to get position of object
    }
  
    // Update is called once per frame
   private void Update()
    {
       HandleAiming();
       HandleShooting();
       
       shootTimer+= Time.deltaTime;
       if (shootTimer >2 )
       {
        doShoot = true;
       }
    }
    //CodeMonkey way to move player according to mouse
    private void HandleAiming()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        aimTransform.LookAt(mousePosition);
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
       // float angle =Mathf.Atan2(aimDirection.y , aimDirection.x)*Mathf.Rad2Deg;
        float angle =Mathf.Atan2(aimDirection.y, aimDirection.z)*Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0,angle,0);
    }
    private void HandleShooting()
    {
        //Basially we get on click position which is also the aiming position as well and spawn object there
        //Destroy with delay is used to make sure too many large objects dont pile up
        //to keep the illusion of invisible force the sprite renderer is simply turned off
        if(Input.GetMouseButtonDown(0) && doShoot)
        {
            int index = Random.Range(0, bullet.Length);
            Vector3 mousePosition = GetMouseWorldPosition();
            Vector3 shootDirection = (mousePosition - transform.position).normalized; 
            var instance = Instantiate(bullet[index], bulletSpawnPoint.transform.position, bullet[index].transform.rotation);
            instance.GetComponent<Rigidbody>().AddForce(shootDirection*5, ForceMode.Impulse);
            this.gameObject.GetComponent<Renderer>().material.color = instance.GetComponent<Renderer>().material.color;
            //instance.transform.Translate(new Vector3 (transform.position.x + 1, transform.position.y + 1 , 0) , Space.Self);
            doShoot = false;
            shootTimer =0;
        }
    }
   
    //Get world Position with Z = 0F by CodeMonkey
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionwithZ(Input.mousePosition, Camera.main);
        vec.z = 0.0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionwithZ()
    {
        return GetMouseWorldPositionwithZ(Input.mousePosition , Camera.main);
    }
    public static Vector3 GetMousePositionwithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionwithZ(Input.mousePosition , worldCamera);
    }
     public static Vector3 GetMouseWorldPositionwithZ(Vector3 screenPosition , Camera worldCamera)
     {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
     }
    //World Position by Codemonkey ends
    
}
