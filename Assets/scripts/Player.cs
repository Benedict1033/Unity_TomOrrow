using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : PlayerLiving
{
    public static float MoveSpeed = 50f;
    PlayerController controller;
    GunController gunController;


    Camera viewCamera;


    public GameObject ps;


    public AudioSource ulti_sound;

    public AudioSource shoot_sound;

 

    protected override void Start()
    {
        base.Start();
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
        viewCamera = Camera.main;
    }

    void Update()
    {
        Debug. Log ( Player. MoveSpeed );

        if ( xpbar. XP.fillAmount==1 )
        {
            if ( Input. GetMouseButtonDown ( 1 ) )
            {
                Instantiate ( ps, transform. position=new Vector3 ( this. transform. position. x, this. transform. position. y, this. transform. position. z ), Quaternion. identity );

                xpbar.XP_Amount=0;
                ulti_sound. Play ( );
            }
        }

        //if ( Input. GetMouseButtonDown ( 1 ) )
        //{
        //    Instantiate ( ps, transform. position=new Vector3 ( this. transform. position. x, this. transform. position. y, this. transform. position. z ), Quaternion. identity );

        //    xpbar. XP_Amount=0;
        //    ulti_sound. Play ( );
        //}







        //movement input
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * MoveSpeed;
        controller.Move (moveVelocity);

        //look input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if(groundPlane.Raycast(ray,out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.red);
            //Debug.Log("Distance :"+point);

            controller.LookAt(point);

        }

        //weapon input
        if(Input.GetMouseButton(0))
        {
            gunController.Shoot();
        //    shoot_sound. Play ( );
        }
   

     

        //  Debug. Log ( LivingEntity.health );

    }

    private void OnTriggerEnter ( Collider other )
    {
        if ( other. gameObject. tag=="enemy" )
        {
            playerhealth. HP-=0.2f;
        }
    }



  
}
