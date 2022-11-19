using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject[] attackpoint;
    public GameObject attackprefab;

    private float currentTime;
    private float NextTime;
    Transform target;
    int damage = 1;



    public static float KilledTime ;
    int i = 0;
    PlayerLiving targetEntity;
    

    void Start ( )
    {
        if ( GameObject. FindGameObjectsWithTag ( "Player" )!=null )
        {

            target=GameObject. FindGameObjectWithTag ( "Player" ). transform;
            targetEntity=target. GetComponent<PlayerLiving> ( );
        }
    }
    void Update ( )
    {
        currentTime+=Time. deltaTime;



        if ( currentTime>NextTime&&currentTime<KilledTime )
        {
            i=Random. Range ( 0, 3 );
            Instantiate ( attackprefab, attackpoint [ i ]. transform. position, Quaternion. identity );
            //targetEntity. TakeDamage ( damage );

            Debug. Log ( 122222222223123123 );
            NextTime=currentTime+1;
        }

        if ( currentTime>KilledTime&&NextTime<KilledTime+1 )
        {
            NextTime=0;
            currentTime=0;

        }
    }

}
