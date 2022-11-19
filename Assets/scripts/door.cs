using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animator anim;

    public Animator anim_elavotor;

    public Animator Level_two;

    public Animator move;

    public GameObject ground;

    private void OnTriggerEnter ( Collider other )
    {
        if ( other. gameObject. tag=="Player" )
        {
            anim. SetBool ( "close", true );

            anim_elavotor. SetBool ( "up", true );

            Level_two. SetBool ( "lv2", true );

     

            StartCoroutine ( fall ( ) );

            spawner. meow ( );

            Player. MoveSpeed=0;

        }
    }

    
    IEnumerator fall ( )
    {
        yield return new WaitForSeconds ( 3f );

     

        ground. SetActive ( true );

      

        this. gameObject. SetActive ( false );

        move. SetBool ( "move", true );


    }





}
