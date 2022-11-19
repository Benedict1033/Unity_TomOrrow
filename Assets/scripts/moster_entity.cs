using System. Collections;
using System. Collections. Generic;
using UnityEngine;

public class moster_entity : MonoBehaviour, Idamageble
{
    public float startingHealth;
    public static float health;
    protected bool dead;

    public event System.Action OnDeath;

    public static int enemy_count;


    public static int killed;




    protected virtual void Start ( )
    {
        health=startingHealth;
    }

    public void Update ( )
    {
     
    }

    public virtual void TakeHit ( int damage, Vector3 hitPoint, Vector3 hitDirection )
    {
        TakeDamage ( damage );
    }

    public virtual void TakeDamage ( int damage )
    {
        health-=damage;

       

        if ( health<=0&&!dead )
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
        }

        GameObject. Destroy ( gameObject,1 );

        //  enemy_count++;
        killed++;
        spawner. nextlv--;
        xpbar. XP_Amount+=0.2f;

    }



}
