using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingzone : MonoBehaviour
{
    void OnTriggerEnter ( Collider col )
    {
        if ( col. gameObject. tag. Equals ( "Player" )&&playerhealth. HP<=1.0 )
            StartCoroutine ( "Heal" );

    }

    private void OnTriggerStay ( Collider col )
    {
        if ( col. gameObject. tag. Equals ( "Player" ) )
        {
            if ( PlayerLiving. health<=4 )
            {
                PlayerLiving. health++;
         
            }
        }

          
    }

    void OnTriggerExit ( Collider col )
    {
        if ( col. gameObject. tag. Equals ( "Player" )&&playerhealth. HP<=1.0 )

            StopCoroutine ( "Heal" );

    }

    IEnumerator Heal ( )
    {
        for ( float currentHealth = playerhealth. HP;
            currentHealth<=1.0f;
            currentHealth+=0.004f )
        {
            playerhealth. HP=currentHealth;
            yield return new WaitForSeconds ( Time. deltaTime );
        }



    }

    private void Update ( )
    {
        //   Debug.Log( playerhealth. HP);

     //   Debug. Log ( PlayerLiving. health );
    }
}
