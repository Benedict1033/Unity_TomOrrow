using System. Collections;
using System. Collections. Generic;
using UnityEngine;

public class PlayerLiving : MonoBehaviour, Idamageble
{
    public int startingHealth;
    public static int health;
    protected bool dead;
    public GameObject panal;



    public event System.Action OnDeath;



    protected virtual void Start ( )
    {
        health=startingHealth;
        panal. SetActive ( false );



    }



    public virtual void TakeHit ( int damage, Vector3 hitPoint, Vector3 hitDirection )
    {
        TakeDamage ( damage );
    }

    public virtual void TakeDamage ( int damage )
    {
        //  health-=damage;
        playerhealth. HP-=0.2f;
        //Debug. Log ( health );

        if ( playerhealth. HP<=0&&!dead )
        {
            Die ( );

        }
    }

    [ContextMenu ( "Self Destruct" )]
    protected void Die ( )
    {
        dead=true;
        if ( OnDeath!=null )
        {
            OnDeath ( );
            panal. SetActive ( true );
        }

        GameObject. Destroy ( gameObject );

    }
}