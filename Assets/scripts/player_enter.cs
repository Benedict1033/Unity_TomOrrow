using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_enter : MonoBehaviour
{


    public Animator down;
    public GameObject ground;
    //  public Animator cam;

    public GameObject moster;


    // public Animator elavator;

    void OnTriggerEnter ( Collider col )
    {
        if ( col. gameObject. tag. Equals ( "Player" ) )
        {
            down. SetBool ( "move2", true );


       //     cam. SetBool ( "lv3", true );

            StartCoroutine ( wait ( ) );

         //   elavator. SetBool ( "up", true );
        
        }
         
 
    }

    IEnumerator wait ( )
    {
        yield return new WaitForSeconds ( 2 );

        moster. SetActive ( true );

        ground. SetActive ( true );

        this. gameObject. SetActive ( false );

   

       

    }
}
