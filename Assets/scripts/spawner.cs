using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. UI;

public class spawner : MonoBehaviour
{
    public GameObject []SpawnPoint;
    public GameObject []Monster;
    public float NextTime;
    public float currentTime;
    public float rate;
    public float time=10;

    private static int a;
    private static int b;

    public static int nextlv=15;

    public GameObject g2;

    public Text enemy_count;

    public Text kill_count;

    public static bool spawn=true;
    public static bool spawn2=false;
    public static bool G2=false;

    public static int i;

    public GameObject fly;
    public GameObject g3;

    public GameObject ssspppp;

    public GameObject water;
    public GameObject water2;



    void Update ( )
    {
        kill_count. text=( ""+LivingEntity.killed);

       // Debug. Log ( nextlv );

        enemy_count. text=( ""+nextlv );

        if ( nextlv<=0 )
        {
            enemy_count. text=( "0");
        }

        if ( LivingEntity. enemy_count==nextlv )
        {
            g2. SetActive ( true );
            G2=true;
            spawn=false;

          

        }

        if ( spawn2 )
        {
            Player. MoveSpeed=50;
            currentTime+=Time. deltaTime*5;
            if ( currentTime>NextTime&&currentTime<time )
            {
                a=Random. Range ( 0, 3 );
                b=Random. Range ( 0, 6 );

                Instantiate ( Monster [ a ], SpawnPoint [ b ]. transform. position, Quaternion. identity );
                NextTime=currentTime+rate;


            }
            if ( currentTime>11&&NextTime<12 )
            {
                NextTime=1;
                currentTime=0;

            }
        }

        if ( spawn )
        {

            currentTime+=Time. deltaTime*2;
            if ( currentTime>NextTime&&currentTime<time )
            {
                a=Random. Range ( 0, 3 );
                b=Random. Range ( 0, 6 );

                Instantiate ( Monster [ a ], SpawnPoint [ b ]. transform. position, Quaternion. identity );
                NextTime=currentTime+rate;


            }
            if ( currentTime>11&&NextTime<12 )
            {
                NextTime=1;
                currentTime=0;

            }
        }

        if ( i==1)
        {
            StartCoroutine ( re ( ) );
            water. SetActive ( false );
        }

        if ( i==2&&nextlv==0 )
        {
           

            ssspppp. SetActive ( false );

            fly. SetActive ( true );
            g3. SetActive ( true );
            i=3;

        
        }
    }



    public static void meow ( )
    {
        i++;
    }

   

   IEnumerator re ( )
    {
        yield return new WaitForSeconds ( 10 );
        nextlv=30;
        spawn2=true;


      


        i=2;

        StartCoroutine ( re2 ( ) );

    }

    IEnumerator re2 ( )
    {
        yield return new WaitForSeconds ( 2 );


        water2. SetActive ( true );

    }



}
